using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD {

    public static class TowerDomain {

        #region Lifecycle
        public static TowerEntity Spawn_HasPos(GameContext ctx, int typeID, Vector2Int pos, IDSignature idsigMap, TowerSpawnTM spawnTM) {

            TowerEntity entity = GameFactory.Tower_Create_hasPos(ctx, typeID, pos, idsigMap, spawnTM);

            ctx.towerRepository.Add(entity);
            return entity;
        }

        public static TowerEntity Spawn(GameContext ctx, int typeID, Vector2Int pos, IDSignature idsigMap) {

            TowerEntity entity = GameFactory.Tower_Create(ctx, typeID, pos, idsigMap);

            ctx.towerRepository.Add(entity);
            return entity;
        }

        public static void UnSpawn(GameContext ctx, TowerEntity entity) {
            ctx.towerRepository.Remove(entity);
            entity.TearDown();
        }
        #endregion

        static void ShootBullet(GameContext ctx, TowerEntity entity, float dt) {
            entity.shootTimer += dt;
            if (entity.shootTimer >= entity.shootInterval) {
                entity.shootTimer = 0;
                BulletDomain.Spawm(ctx, BulletConst.TowerBlt, entity.transform.position);
            }
        }

        // TowerArraw
        public static void SpawnBullet(GameContext ctx, TowerEntity tower, float dt) {

            int len = ctx.roleRepository.TakeAll(out RoleEntity[] msts);

            for (int i = 0; i < len; i++) {
                RoleEntity mst = msts[i];
                bool isRole = mst.fsmCom.isRole;
                if (isRole) {

                } else {
                    float distance = Vector2.Distance(mst.transform.position, tower.transform.position);
                    if (distance < tower.attackRange) {
                        ShootBullet(ctx, tower, dt);
                    }
                }
            }
        }


        // BaseTower 怪物碰到基地 基地扣血 mst消失
        public static void BaseTowerHpReduce(GameContext ctx, TowerEntity baseTower) {

            int lenMst = ctx.roleRepository.TakeAll(out RoleEntity[] msts);
            for (int i = 0; i < lenMst; i++) {
                RoleEntity mst = msts[i];
                bool isRole = mst.fsmCom.isRole;
                if (isRole) {
                    continue;
                }
                float distance = Vector2.Distance(mst.transform.position, baseTower.transform.position);
                if (distance < 0.5) {
                    RoleDomain.UnSpawn(ctx, mst);
                    baseTower.hp -= mst.attackHurt;
                    if (baseTower.hp <= 0) {
                        baseTower.hp = 0;
                    }
                }
            }
        }

        // TreeTower

        #region TowerTree
        // 找到最近的树然后砍树
        public static void FindNearestTree(GameContext ctx, TowerEntity tower, float dt) {

            TreeEntity nearestTree = Physics.FindNearestTree(ctx, tower);
            if (nearestTree != null) {
                // 砍树
                CutTree(ctx, tower, nearestTree, dt);
            } else {
                // 关闭提示框
                ctx.appUI.HUD_GatherHint_Close(tower.idSig);
            }
        }
        public static void CutTree(GameContext ctx, TowerEntity tower, TreeEntity tree, float dt) {
            var game = ctx.gameEntity;

            // 打开提示跳血调 === HUD的IDsig 和 tower的IDsig 一样
            ctx.appUI.HUD_GatherHint_Open(tower.idSig);
            Vector3 pos = new Vector3(tree.pos.x, tree.pos.y + 0.5f, 0);
            ctx.appUI.HUD_GatherHint_SetPos(pos,tower.idSig);

            tower.cutTreeTime += dt;
            ctx.appUI.HUD_GatherHint_SetHint(tower.cutTreeTime, tower.cutTreeInterval,tower.idSig);

            if (tower.cutTreeTime >= tower.cutTreeInterval) {
                tower.cutTreeTime = 0;
                tree.resCount -= tower.cutHurt;
                game.resCount += tower.cutHurt;
                if (tree.resCount <= 0) {
                    // TODO: 播放金币动画

                    Debug.Log("砍树");
                    TreeDomain.UnSpawn(ctx, tree);
                    MapEntity map = ctx.mapRepository.GetMapByMousePos(Vector2Int.zero);
                    MapDomain.DeleteCells(ctx, map, (Vector3Int)tree.pos);
                }
            }

        }
        #endregion

        public static void Clear(GameContext ctx) {
            int len = ctx.towerRepository.TakeAll(out TowerEntity[] towers);
            for (int i = 0; i < len; i++) {
                TowerEntity tower = towers[i];
                UnSpawn(ctx, tower);
            }
        }

    }
}