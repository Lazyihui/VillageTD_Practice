using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD {

    public static class TowerDomain {

        #region Lifecycle
        public static TowerEntity Spawn(GameContext ctx, int typeID, Vector2Int pos) {

            TowerEntity entity = GameFactory.Tower_Create(ctx, typeID, pos);

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
                if (mst.typeID == RoleConst.Role) {

                } else {
                    float distance = Vector2.Distance(mst.transform.position, tower.transform.position);
                    if (distance < tower.attackRange) {
                        ShootBullet(ctx, tower, dt);
                    }
                }
            }
        }


        // BaseTower
        public static void BaseTowerHpReduce(GameContext ctx, TowerEntity baseTower) {

            int lenMst = ctx.roleRepository.TakeAll(out RoleEntity[] msts);

            for (int i = 0; i < lenMst; i++) {
                RoleEntity mst = msts[i];
                if (mst.typeID == RoleConst.Role) {
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

            int len = ctx.treeRepository.TakeAll(out TreeEntity[] trees);
            float minDistance = float.MaxValue;
            TreeEntity nearestTree = null;
            for (int i = 0; i < len; i++) {
                TreeEntity tree = trees[i];
                float distance = Vector2.Distance(tree.pos, tower.transform.position);
                if (distance < minDistance && distance < tower.attackRange) {
                    minDistance = distance;
                    nearestTree = tree;
                }
                if (distance < tower.attackRange) {
                    // 砍树
                    ctx.treeRepository.RemovePos(tree.pos);
                }
            }
            if (nearestTree != null) {
                // 砍树
                CutTree(ctx, tower, nearestTree, dt);
            }
        }
        public static void CutTree(GameContext ctx, TowerEntity tower, TreeEntity tree, float dt) {
            tower.cutTreeTime += dt;
            if (tower.cutTreeTime >= tower.cutTreeInterval) {
                tower.cutTreeTime = 0;
                tree.resCount -= tower.cutHurt;
                ctx.gameEntity.resCount += tower.cutHurt;
                if (tree.resCount <= 0) {
                    TreeDomain.UnSpawn(ctx, tree);
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