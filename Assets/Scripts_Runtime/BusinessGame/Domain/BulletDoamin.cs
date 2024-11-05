using System;
using UnityEngine;



namespace TD {


    public static class BulletDomain {

        public static BulletEntity Spawm(GameContext ctx, int typeID, Vector2 pos) {

            BulletEntity entity = GameFactory.Bullet_Create(ctx, typeID, pos);

            ctx.bulletRepository.Add(entity);

            return entity;

        }

        public static void FindNearest(GameContext ctx, BulletEntity entity, float dt) {

            int len = ctx.roleRepository.TakeAll(out RoleEntity[] roles);

            float minDistance = float.MaxValue;
            RoleEntity nearestMst = null;

            for (int i = 0; i < len; i++) {
                RoleEntity role = roles[i];
                if (role.typeID == RoleConst.Role) {
                } else {
                    float distance = Vector2.Distance(role.transform.position, entity.transform.position);
                    if (distance < minDistance) {
                        minDistance = distance;
                        nearestMst = role;
                    }
                }
            }

            if (nearestMst != null) {
                // 子弹向最近的目标移动
                BulletDomain.MoveToTarget(entity, nearestMst, dt);
            }

        }



        public static void MoveToTarget(BulletEntity blt, RoleEntity target, float dt) {
            Vector2 dir = target.transform.position - blt.transform.position;
            dir.Normalize();
            blt.transform.position += new Vector3(dir.x * dt, dir.y * dt, 0);
        }


    }
}