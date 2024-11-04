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

        public static void Set_MoveAxis(RoleEntity entity, Vector2 moveAxis) {
            entity.Set_MoveAxis(moveAxis);
        }

        public static void Move(RoleEntity entity, float dt) {
            entity.Move(dt);
        }
    }
}