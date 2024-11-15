using System;
using UnityEngine;



namespace TD {


    public static class BulletDomain {

        public static BulletEntity Spawm(GameContext ctx, int typeID, Vector2 pos) {
            BulletEntity entity = GameFactory.Bullet_Create(ctx, typeID, pos);
            entity.onTriggerEnter = (Collider2D other) => {

                BulletTrigger2D(other, ctx, entity);
            };
            ctx.bulletRepository.Add(entity);
            return entity;

        }

        static void BulletTrigger2D(Collider2D other, GameContext ctx, BulletEntity entity) {
            if (other.gameObject.tag == "Mst") {

                RoleEntity mst = other.gameObject.GetComponentInParent<RoleEntity>();
                mst.hp -= 1;
                if (mst.hp <= 0) {
                    RoleDomain.UnSpawn(ctx, mst);
                }
                UnSpawn(ctx, entity);

            }

        }

        public static void UnSpawn(GameContext ctx, BulletEntity entity) {
            ctx.bulletRepository.Remove(entity);
            entity.TearDown();
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

            if (nearestMst != null && entity.targetIDSig.entityID == -1) {
                entity.targetIDSig = nearestMst.idSig;
            }

        }

        public static void MoveToTarget(GameContext ctx, BulletEntity blt, float dt) {

            bool has = ctx.roleRepository.TryGet(blt.targetIDSig, out RoleEntity target);
            if (!has) {
                if (blt.targetIDSig.entityID != -1) {
                    UnSpawn(ctx, blt);
                }
                return;
            }
            Vector2 dir = target.transform.position - blt.transform.position;
            dir.Normalize();
            blt.transform.position += new Vector3(dir.x * dt * blt.moveSpeed, dir.y * dt * blt.moveSpeed, 0);
        }

        public static void Clear(GameContext ctx) {
            int len = ctx.bulletRepository.TakeAll(out BulletEntity[] bullets);
            for (int i = 0; i < len; i++) {
                BulletEntity bullet = bullets[i];
                UnSpawn(ctx, bullet);
            }
        }

    }
}