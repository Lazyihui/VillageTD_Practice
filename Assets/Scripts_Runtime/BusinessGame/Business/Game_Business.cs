using System;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public static class Game_Business {

        public static void Enter(GameContext ctx) {

            MapEntity map = MapDomain.Spawn(ctx, 1);


            RoleEntity owner = RoleDomain.Spawn(ctx, RoleConst.Role, new Vector2(0, 0));
            ctx.gameEntity.ownerID = owner.id;

            TowerDoamin.Spawn(ctx, TowerConst.BaseTower);

            HashSet<Vector2Int> treePosHashSet = MapDomain.GetTilePos(map.treeTile.tile);

            foreach (Vector2Int pos in treePosHashSet) {
                TreeDomain.Spawn(ctx, pos, 1);
            }

            int len = ctx.treeRepository.TakeAll(out TreeEntity[] trees);

            // panel
            ctx.appUI.Panel_Manifaset_Open(ctx);

            ctx.appUI.Panel_ResourceInfo_Open(ctx);

        }


        public static void Tick(GameContext ctx, float dt) {
            PreTick(ctx, dt);

            ref float restFixTime = ref ctx.gameEntity.restFixTime;

            restFixTime += dt;

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


            RoleEntity owner = ctx.Role_GetOwner();

            RoleDomain.Set_MoveAxis(owner, ctx.inputEntity.moveAxis);

            // panel  Update
            ctx.appUI.Panel_ResourceInfo_UpateResCount(ctx);


        }

        static void LogicTick(GameContext ctx, float dt) {

            GameDomain.SetTowerPos(ctx);
            GameDomain.BulidTowerArraw(ctx);
            GameDomain.BulidTowerTree(ctx);
            GameDomain.CancelBulidTower(ctx);

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
                TowerDoamin.SetCollider(tower);

                if (tower.typeID == TowerConst.BaseTower) {
                    TowerDoamin.BaseTowerHpReduce(ctx, tower);
                } else if (tower.typeID == TowerConst.ArrowTower && tower.isLive) {
                    TowerDoamin.SpawnBullet(ctx, tower, dt);
                } else if (tower.typeID == TowerConst.TreeTower && tower.isLive) {
                    TowerDoamin.FindNearestTree(ctx, tower, dt);
                }


            }

            int lenBullet = ctx.bulletRepository.TakeAll(out BulletEntity[] bullets);

            for (int i = 0; i < lenBullet; i++) {
                BulletEntity bullet = bullets[i];
                BulletDomain.FindNearest(ctx, bullet, dt);
            }



            SpawnMst(ctx, dt);


        }
        // 要改
        static void SpawnMst(GameContext ctx, float dt) {

            ctx.caveEntity.caveSpawnTime += dt;

            if (ctx.caveEntity.caveSpawnTime >= ctx.caveEntity.caveSpawnInterval) {
                ctx.caveEntity.caveSpawnTime = 0;
                RoleDomain.Spawn(ctx, RoleConst.Monster, new Vector2(17, 0));

            }

        }

        static void LastTick(GameContext ctx, float dt) {

            // //相机跟随   
            // RoleEntity owner = ctx.Role_GetOwner();
            // ctx.cameraCore.Follow(owner.transform.position);
        }
    }
}