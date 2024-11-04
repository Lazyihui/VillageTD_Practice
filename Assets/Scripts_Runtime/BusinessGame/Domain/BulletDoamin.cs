using System;
using UnityEngine;



namespace TD {


    public static class BulletDomain {

        public static BulletEntity Spawm(GameContext ctx, int typeID, Vector2 pos) {

            BulletEntity entity = GameFactory.Bullet_Create(ctx, typeID, pos);

            ctx.bulletRepository.Add(entity);

            return entity;

        }

        public static void FindNestEnemy(GameContext ctx, BulletEntity entity) {
            float minDistance = 1000;
            RoleEntity target = null;

            int len = ctx.roleRepository.TakeAll(out RoleEntity[] roles);

            for (int i = 0; i < len; i++) {
                RoleEntity role = roles[i];

                float distance = Vector2.Distance(role.transform.position, entity.transform.position);
                Debug.Log("distance: " + distance);

                if (distance < minDistance && distance < entity.attackRange) {
                    minDistance = distance;
                    target = role;
                }

            }

            
        }
    }
}