using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {

    public static class RoleDomain {

        public static RoleEntity Spawn(GameContext ctx) {
            GameObject prefab = ctx.assetsCore.Entity_GetRole();
            if (prefab == null) {
                Debug.LogError("Role prefab is null");
                return null;
            }

            GameObject go = GameObject.Instantiate(prefab);
            RoleEntity entity = go.GetComponent<RoleEntity>();

            entity.Ctor();

            ctx.roleRepository.Add(entity);

            return entity;
        }
    }
}