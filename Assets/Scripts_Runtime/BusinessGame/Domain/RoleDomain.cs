using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {

    public static class RoleDomain {

        public static RoleEntity Spawn(GameContext ctx,int typeID) {

            
            // ctx.templateCore.ctx.Role_TryGet(typeID,out RoleTM tm);

            // if(tm == null) {
            //     Debug.LogError("RoleDomain.Spawn: RoleTM is null");
            //     return null;
            // }

            GameObject prefab = ctx.assetsCore.Entity_GetRole();
            if (prefab == null) {
                Debug.LogError("Role prefab is null");
                return null;
            }

            GameObject go = GameObject.Instantiate(prefab);
            RoleEntity entity = go.GetComponent<RoleEntity>();

            entity.Ctor();

            // entity.typeID = tm.typeID;

            Debug.Log("RoleDomain.Spawn: typeID = " + entity.typeID);

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