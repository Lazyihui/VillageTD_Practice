using System;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public static class Game_Business {

        public static void Enter(GameContext ctx) {




            ctx.gameEntity.state = GameState.Game;

            int stageID = ctx.gameEntity.stageID;
            bool has = ctx.templateCore.Stage_TryGet(stageID, out StageTM tm);
            if (!has) {
                Debug.LogError("Stage 1 not found");
            }

            RoleSpawnTM[] roleSpawnerTMs = tm.roleSpawnTMs;

            for (int i = 0; i < roleSpawnerTMs.Length; i++) {
                RoleSpawnTM role = roleSpawnerTMs[i];
                RoleEntity entity = RoleDomain.SpawnBySpawnerRole(ctx, role.so.tm.typeID, new Vector3(0, 0, 0), role);
                ctx.idService.ownerIDSig = entity.idSig;
            }

            CaveSpawnTM[] caveSpawnerTMs = tm.caveSpawnTMs;
            for (int i = 0; i < caveSpawnerTMs.Length; i++) {
                CaveSpawnTM cave = caveSpawnerTMs[i];
                CaveDomain.Spawn(ctx, cave.so.tm.typeID, cave);
            }


            MapEntity map = MapDomain.Spawn(ctx, tm.mapEntity);
            TowerDomain.Spawn(ctx, TowerConst.BaseTower, new Vector2Int(0, 0));


            HashSet<Vector2Int> treePosHashSet = MapDomain.GetTilePos(map.treeGrid.tile);

            foreach (Vector2Int pos in treePosHashSet) {

                TreeDomain.Spawn(ctx, pos, 1);
            }


            // panel
            ctx.appUI.Panel_Manifaset_Open();

            #region  Panel_Manifaset_Open
            ctx.appUI.Panel_Manifast_AddElement(1);
            ctx.appUI.Panel_Manifast_AddElement(2);
            ctx.appUI.Panel_Manifast_AddElement(3);
            #endregion

            ctx.appUI.Panel_ResourceInfo_Open();
            ctx.appUI.Panel_Guide_Open();

        }


        public static void Tick(GameContext ctx, float dt) {
            PreTick(ctx, dt);

            ref float restFixTime = ref ctx.gameEntity.restFixTime;

            restFixTime += dt;
            const float FIX_INTERVAL = 0.020f;

            if (restFixTime <= FIX_INTERVAL) {

                LogicTick(ctx, restFixTime);

                restFixTime = 0;
            } else {
                while (restFixTime >= FIX_INTERVAL) {
                    LogicTick(ctx, FIX_INTERVAL);
                    restFixTime -= FIX_INTERVAL;
                }
            }

            LastTick(ctx, dt);
        }


        static void PreTick(GameContext ctx, float dt) {


            UserInteractDomain.Tick(ctx, dt);

            RoleEntity owner = ctx.Role_GetOwner();

            RoleDomain.Set_MoveAxis(owner, ctx.inputEntity.moveAxis);

            // panel  Update
            ctx.appUI.Panel_ResourceInfo_UpateResCount(ctx.gameEntity.resCount);

        }

        static void LogicTick(GameContext ctx, float dt) {

            GameEntity game = ctx.gameEntity;

            RoleEntity owner = ctx.Role_GetOwner();
            RoleDomain.Move(owner, dt);
            RoleDomain.SpawnBullet(ctx, owner, dt);


            int lenMst = ctx.roleRepository.TakeAll(out RoleEntity[] msts);
            for (int i = 0; i < lenMst; i++) {
                RoleEntity mst = msts[i];
                bool isRole = mst.fsmCom.isRole;
                if (isRole) {
                    continue;
                }
                RoleDomain.MoveByPath(mst);

            }

            TowerEntity baseTower = ctx.Tower_GetOwner();

            int lenTower = ctx.towerRepository.TakeAll(out TowerEntity[] towers);
            for (int i = 0; i < lenTower; i++) {
                TowerEntity tower = towers[i];
                if (tower.fsmCom.isBaseTower) {
                    TowerDomain.BaseTowerHpReduce(ctx, tower);
                } else if (tower.fsmCom.isArrowTower) {
                    TowerDomain.SpawnBullet(ctx, tower, dt);
                } else if (tower.fsmCom.isTreeTower) {
                    TowerDomain.FindNearestTree(ctx, tower, dt);
                }

            }

            int lenBullet = ctx.bulletRepository.TakeAll(out BulletEntity[] bullets);

            for (int i = 0; i < lenBullet; i++) {
                BulletEntity bullet = bullets[i];
                // 找到最近的mst
                BulletDomain.FindNearest(ctx, bullet, dt);
                // 找到目标
                BulletDomain.Get_TargetMst(ctx, bullet, dt);
                // 向目标移动
                BulletDomain.MoveToTarget(ctx, bullet, dt);
                // 超出边界销毁
                BulletDomain.OverBorderUnSpawn(ctx, bullet);
            }

            int lenCave = ctx.caveRepository.TakeAll(out CaveEntity[] caves);

            for (int i = 0; i < lenCave; i++) {
                CaveEntity cave = caves[i];
                // 激活cave 按时间来
                CaveDomain.ActiveCave(ctx, cave, dt);
                // 生成mst
                if (cave.isLive) {
                    // 是否生成完
                    game.isCavrSpawnMstOver = CaveDomain.CaveSpawnMst(ctx, cave, dt);
                }
            }


        }



        // 要改


        static void LastTick(GameContext ctx, float dt) {

            // //相机跟随   
            // RoleEntity owner = ctx.Role_GetOwner();
            // ctx.cameraCore.Follow(owner.transform.position);

            // 清除所有数据
            GameDomain.Tick(ctx, dt);
        }
    }
}