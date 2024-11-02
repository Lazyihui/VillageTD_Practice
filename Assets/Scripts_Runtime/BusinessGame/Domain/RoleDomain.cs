using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {

    public static class RoleDomain {

        public static RoleEntity Spawn(GameContext ctx, int typeID) {


            RoleTM tm;

            bool has = ctx.templateCore.ctx.Role_TryGet(typeID, out tm);

            if(!has) {
                Debug.LogError("RoleDomain.Spawn: typeID = " + typeID + " not found");
                return null;
            }


            GameObject prefab = ctx.assetsCore.Entity_GetRole();

            GameObject go = GameObject.Instantiate(prefab);
            RoleEntity entity = go.GetComponent<RoleEntity>();


            Debug.Assert(entity != null, "RoleEntity is null");
            Debug.Assert(tm != null, "RoleTM is null");

            // 还没有用到SpawnTM

            // mod就是图片
            // GameObject mod = GameObject.Instantiate(tm.modPrefab, entity.transform);

            entity.Ctor();

            entity.typeID = tm.typeID;


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