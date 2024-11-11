using System;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public static class Game_Business {

        public static void Enter(GameContext ctx) {



            bool has = ctx.templateCore.Stage_TryGet(1, out StageTM tm);
            if (!has) {

                Debug.LogError("Stage 1 not found");
            }

            Debug.Log("创建关卡");

            RoleSpawnTM[] roleSpawnerTMs = tm.roleSpawnTMs;

            for (int i = 0; i < roleSpawnerTMs.Length; i++) {
                RoleSpawnTM role = roleSpawnerTMs[i];

                RoleEntity entity = RoleDomain.SpawnBySpawner(ctx, role.so.tm.typeID, new Vector3(0, 0, 0), role);
                ctx.gameEntity.ownerIDSig = entity.idSig;

            }

            CaveSpawnTM[] caveSpawnerTMs = tm.caveSpawnTMs;

            for (int i = 0; i < caveSpawnerTMs.Length; i++) {
                CaveSpawnTM cave = caveSpawnerTMs[i];
                CaveDomain.Spawn(ctx, cave.so.tm.typeID, cave);
                
            }










            MapEntity map = MapDomain.Spawn(ctx, 1);


            // RoleEntity owner = RoleDomain.Spawn(ctx, RoleConst.Role, new Vector2(0, 0));
            // ctx.gameEntity.ownerIDSig = owner.idSig;

            TowerDoamin.Spawn(ctx, TowerConst.BaseTower, new Vector2Int(0, 0));

            HashSet<Vector2Int> treePosHashSet = MapDomain.GetTilePos(map.treeGrid.tile);

            foreach (Vector2Int pos in treePosHashSet) {
                TreeDomain.Spawn(ctx, pos, 1);
            }




            // panel
            ctx.appUI.Panel_Manifaset_Open();

            ctx.appUI.Panel_ResourceInfo_Open();


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

            UserInteractDomain.Tick(ctx);




            RoleEntity owner = ctx.Role_GetOwner();

            RoleDomain.Set_MoveAxis(owner, ctx.inputEntity.moveAxis);

            // panel  Update
            ctx.appUI.Panel_ResourceInfo_UpateResCount(ctx.gameEntity.resCount);


        }

        static void LogicTick(GameContext ctx, float dt) {

            GameEntity game = ctx.gameEntity;

            GameDomain.Tick(ctx, dt);
            RoleEntity owner = ctx.Role_GetOwner();
            RoleDomain.Move(owner, dt);
            RoleDomain.SpawnBullet(ctx, owner, dt);


            int lenMst = ctx.roleRepository.TakeAll(out RoleEntity[] msts);
            for (int i = 0; i < lenMst; i++) {
                RoleEntity mst = msts[i];
                if (mst.typeID == RoleConst.Role) {
                    continue;
                }
                RoleDomain.MstMove(mst, dt);

            }

            TowerEntity baseTower = ctx.Tower_GetOwner();




            int lenTower = ctx.towerRepository.TakeAll(out TowerEntity[] towers);
            for (int i = 0; i < lenTower; i++) {
                TowerEntity tower = towers[i];
                if (tower.fsmCom.isBaseTower) {
                    TowerDoamin.BaseTowerHpReduce(ctx, tower);
                } else if (tower.fsmCom.isArrowTower) {
                    TowerDoamin.SpawnBullet(ctx, tower, dt);
                } else if (tower.fsmCom.isTreeTower) {
                    TowerDoamin.FindNearestTree(ctx, tower, dt);
                }


            }

            int lenBullet = ctx.bulletRepository.TakeAll(out BulletEntity[] bullets);

            for (int i = 0; i < lenBullet; i++) {
                BulletEntity bullet = bullets[i];
                // 找到最近的mst
                BulletDomain.FindNearest(ctx, bullet, dt);
                // 向最近的mst移动
                BulletDomain.MoveToTarget(ctx, bullet, dt);
            }

            int lenCave = ctx.caveRepository.TakeAll(out CaveEntity[] caves);

            for (int i = 0; i < lenCave; i++) {
                CaveEntity cave = caves[i];
                // 激活cave 按时间来
                CaveDomain.ActiveCave(ctx, cave, dt);
                // 生成mst
                if (cave.isLive) {
                    game.isMstOver = CaveDomain.CaveSpawnMst(ctx, cave, dt);
                }
            }

            if (game.isMstOver) {
                int mstCount = 0;
                int len = ctx.roleRepository.TakeAll(out RoleEntity[] roles);
                for (int i = 0; i < len; i++) {
                    RoleEntity role = roles[i];

                    // 要改
                    if (role.typeID == RoleConst.Role) {
                        continue;
                    }
                    if (role.typeID == RoleConst.Monster) {
                        mstCount++;
                    }
                }

                if (mstCount == 0) {
                    IDSignature idSig = new IDSignature(EntityType.Tower, 0);

                    bool has = ctx.towerRepository.TryGet(idSig, out TowerEntity entity);

                    if (entity.hp > 0) {
                        ctx.appUI.Panel_Over_Open();
                    }

                }

            }

        }



        // 要改


        static void LastTick(GameContext ctx, float dt) {

            // //相机跟随   
            // RoleEntity owner = ctx.Role_GetOwner();
            // ctx.cameraCore.Follow(owner.transform.position);
        }
    }
}