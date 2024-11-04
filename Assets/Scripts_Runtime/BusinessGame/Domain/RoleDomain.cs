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
            if (Input.GetMouseButtonDown(0)) {
                BulletEntity bullet = GameFactory.Bullet_Create(ctx, 0, entity.transform.position);
            }
        }

        // mst

        public static void MstMove(RoleEntity entity, float dt) {
            entity.transform.position -= new Vector3(entity.moveSpeed * dt, 0, 0);
        }

       

    }
}