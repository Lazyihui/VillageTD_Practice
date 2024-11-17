using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {

    public static class RoleDomain {

        public static RoleEntity SpawnBySpawnerRole(GameContext ctx, int typeID, Vector3 pos, RoleSpawnTM spawnTM) {
            RoleEntity entity = GameFactory.Role_Create(ctx, typeID, pos, spawnTM);
            ctx.roleRepository.Add(entity);
            return entity;
        }

        public static RoleEntity SpawnMst(GameContext ctx, int typeID, Vector3 pos, Vector2[] path) {
            RoleEntity entity = GameFactory.Mst_Create(ctx, typeID, pos, path);
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

        public static void MstMove(RoleEntity mst) {

            Vector2 dir = Vector2.left;
            Debug.Log(dir);
            mst.MoveByPath(dir);
        }

        public static void MoveByPath(RoleEntity mst) {

            //  无路径
            if (mst.pathCom.path == null) {
                return;
            }
            int index = mst.pathCom.pathIndex;

            // 有路径但是走完了
            if (index >= mst.pathCom.path.Length) {
                return;
            }
            // 要走的目标点
            Vector2 targetPos = mst.pathCom.path[index];

            Vector2 dir = targetPos - (Vector2)mst.transform.position;
            if (dir.magnitude < 0.1f) {
                mst.pathCom.pathIndex++;
                return;
            } else {
                dir.Normalize();
                mst.MoveByPath(dir);
            }

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