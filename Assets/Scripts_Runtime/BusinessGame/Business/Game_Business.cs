using System;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public static class Game_Business {

        public static void Enter(GameContext ctx) {

            MapEntity map = MapDomain.Spawn(ctx, 1);


            RoleEntity owner = RoleDomain.Spawn(ctx, RoleConst.Role, new Vector2(0, 0));
            ctx.gameEntity.ownerIDSig = owner.idSig;

            TowerDoamin.Spawn(ctx, TowerConst.BaseTower, new Vector2Int(0, 0));

            HashSet<Vector2Int> treePosHashSet = MapDomain.GetTilePos(map.treeGrid.tile);

            foreach (Vector2Int pos in treePosHashSet) {
                TreeDomain.Spawn(ctx, pos, 1);
            }


            CaveDomain.Spawn(ctx, 1, new Vector3(17, 0, 0));


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
                    Debug.Log("ArrowTower");
                    TowerDoamin.SpawnBullet(ctx, tower, dt);
                } else if (tower.fsmCom.isTreeTower) {
                    Debug.Log("TreeTower");
                    TowerDoamin.FindNearestTree(ctx, tower, dt);
                }


            }

            int lenBullet = ctx.bulletRepository.TakeAll(out BulletEntity[] bullets);

            for (int i = 0; i < lenBullet; i++) {
                BulletEntity bullet = bullets[i];
                BulletDomain.FindNearest(ctx, bullet, dt);
            }





        }
        // 要改
        static void SpawnMst(GameContext ctx, float dt) {

            CaveEntity cave = ctx.Cave_GetOwner(0);

            cave.caveSpawnTime += dt;

            if (cave.caveSpawnTime >= cave.caveSpawnInterval) {
                cave.caveSpawnTime = 0;
                Vector3 pos = cave.transform.position;
                RoleDomain.Spawn(ctx, RoleConst.Monster, pos);
            }

        }

        static void LastTick(GameContext ctx, float dt) {
            SpawnMst(ctx, dt);

            // //相机跟随   
            // RoleEntity owner = ctx.Role_GetOwner();
            // ctx.cameraCore.Follow(owner.transform.position);
        }
    }
}