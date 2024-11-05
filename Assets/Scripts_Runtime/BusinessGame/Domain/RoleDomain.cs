using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {

    public static class RoleDomain {

        public static RoleEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {

            RoleEntity entity = GameFactory.Role_Create(ctx, typeID, pos);

            ctx.roleRepository.Add(entity);

            return entity;
        }

        // Role
        public static void Set_MoveAxis(RoleEntity entity, Vector2 moveAxis) {
            entity.Set_MoveAxis(moveAxis);
        }

        public static void Move(RoleEntity entity, float dt) {
            entity.Move(dt);
        }

        public static void ShootBullet(GameContext ctx, RoleEntity entity, float dt) {
            entity.shootTimer += dt;
            if (entity.shootTimer >= entity.shootInterval) {
                entity.shootTimer = 0;
                BulletDomain.Spawm(ctx, 0, entity.transform.position);
            }
        }
        public static void SpawnBullet(GameContext ctx, RoleEntity role, float dt) {

            int len = ctx.roleRepository.TakeAll(out RoleEntity[] msts);

            for (int i = 0; i < len; i++) {
                RoleEntity mst = msts[i];
                if (mst.typeID == RoleConst.Role) {
                } else {

                    float distance = Vector2.Distance(mst.transform.position, role.transform.position);

                    if (distance < role.attackRange) {
                        ShootBullet(ctx, role, dt);
                    }
                }
            }

          
        }


        // mst

        public static void MstMove(RoleEntity entity, float dt) {
            entity.transform.position -= new Vector3(entity.moveSpeed * dt, 0, 0);
        }



    }
}