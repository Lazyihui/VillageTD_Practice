using System;
using UnityEngine;



namespace TD {


    public static class BulletDomain {

        public static BulletEntity Spawm(GameContext ctx, int typeID, Vector2 pos) {

            BulletEntity entity = GameFactory.Bullet_Create(ctx, typeID, pos);

            ctx.bulletRepository.Add(entity);

            return entity;

        }
    }
}