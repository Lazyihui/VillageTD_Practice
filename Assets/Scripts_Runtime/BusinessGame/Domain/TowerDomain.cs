using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD {

    public static class TowerDoamin {

        public static TowerEntity Spawn(GameContext ctx, int typeID) {

            TowerEntity entity = GameFactory.Tower_Create(ctx, typeID);

            ctx.towerRepository.Add(entity);
            return entity;
        }

        public static void UnSpawn(GameContext ctx, TowerEntity entity) {
            ctx.towerRepository.Remove(entity);
            entity.TearDown();
        }


        public static void SetCollider(TowerEntity entity) {
            entity.SetCollider();
        }
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
                    baseTower.hp -= mst.attackHurt;
                    Debug.Log("BaseTowerHpReduce" + baseTower.hp);
                    if (baseTower.hp <= 0) {
                        baseTower.hp = 0;
                        baseTower.isLive = false;
                    }
                }
            }
        }

        // TreeTower
        public static void CutTree(GameContext ctx, TowerEntity toweTree) {

            

        }


    }
}