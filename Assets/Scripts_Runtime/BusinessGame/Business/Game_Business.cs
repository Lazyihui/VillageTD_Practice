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

            // MapDomain.GetTileTreePos(map.treeTile, out Vector3Int pos);
            HashSet<Vector2Int> tilePosHashSet = MapDomain.GetTilePos(map.treeTile.tile);

            foreach (Vector2Int pos in tilePosHashSet) {
                TreeDomain.Spawn(ctx, pos, 1);
            }

            int len = ctx.treeRepository.TakeAll(out TreeEntity[] trees);

            // panel
            ctx.appUI.Panel_Manifaset_Open(ctx);

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


        }

        static void LogicTick(GameContext ctx, float dt) {
            RoleEntity owner = ctx.Role_GetOwner();
            RoleDomain.Move(owner, dt);
            RoleDomain.ShootBullet(ctx, owner, dt);


            int lenMst = ctx.roleRepository.TakeAll(out RoleEntity[] msts);
            for (int i = 0; i < lenMst; i++) {
                RoleEntity mst = msts[i];
                if (mst.typeID == RoleConst.Role) {
                    continue;
                }
                RoleDomain.MstMove(mst, dt);

            }


            int lenTower = ctx.towerRepository.TakeAll(out TowerEntity[] towers);
            for (int i = 0; i < lenTower; i++) {
                TowerEntity tower = towers[i];
                TowerDoamin.SetCollider(tower);
            }


            SpawnMst(ctx, dt);


        }
        // 要改
        static void SpawnMst(GameContext ctx, float dt) {

            ctx.gameEntity.caveSpawnTime += dt;
            if (ctx.gameEntity.caveSpawnTime >= ctx.gameEntity.caveSpawnInterval) {

                ctx.gameEntity.caveSpawnTime = 0;
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