using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {

    public static class RoleDomain {

        public static RoleEntity SpawnBySpawner(GameContext ctx, int typeID, Vector3 pos, RoleSpawnTM spawnTM) {
            RoleEntity entity = GameFactory.Role_Create(ctx, typeID, pos, spawnTM);
            ctx.roleRepository.Add(entity);
            return entity;
        }

        public static RoleEntity Spawn(GameContext ctx, int typeID, Vector3 pos) {
            RoleEntity entity = GameFactory.Role_Create(ctx, typeID, pos);
            ctx.roleRepository.Add(entity);
            return entity;
        }


        public static void UnSpawn(GameContext ctx, RoleEntity entity) {
            ctx.roleRepository.Remove(entity);
            entity.TearDown();
        }


        #region Role
        // Role
        public static void Set_MoveAxis(RoleEntity entity, Vector2 moveAxis) {
            entity.Set_MoveAxis(moveAxis);
        }

        public static void Move(RoleEntity entity, float dt) {
            entity.MoveByInput();
        }

        public static void ShootBullet(GameContext ctx, RoleEntity entity, float dt) {
            entity.shootTimer += dt;
            if (entity.shootTimer >= entity.shootInterval) {
                entity.shootTimer = 0;
                BulletDomain.Spawm(ctx, BulletConst.RoleBlt, entity.transform.position);
            }
        }
        #endregion

        // 主角发射子弹
        public static void SpawnBullet(GameContext ctx, RoleEntity role, float dt) {

            int len = ctx.roleRepository.TakeAll(out RoleEntity[] msts);

            for (int i = 0; i < len; i++) {
                RoleEntity mst = msts[i];
                bool isRole = mst.fsmCom.isRole;
                if (isRole) {

                } else {
                    float distance = Vector2.Distance(mst.transform.position, role.transform.position);
                    if (distance < role.attackRange) {
                        ShootBullet(ctx, role, dt);
                    }
                }
            }

        }

        #region Master

        public static void MstMove(RoleEntity mst, float dt) {
            
            Vector2 dir = Vector2.left;
            Debug.Log(dir);
            mst.MoveByPath(dir, dt);
        }



        public static void Clear(GameContext ctx) {
            int len = ctx.roleRepository.TakeAll(out RoleEntity[] roles);
            for (int i = 0; i < len; i++) {
                RoleEntity role = roles[i];
                UnSpawn(ctx, role);
            }
        }
        #endregion

    }
}