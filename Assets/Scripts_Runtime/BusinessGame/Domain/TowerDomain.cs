using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD {

    public static class TowerDoamin {

        public static TowerEntity Spawn(GameContext ctx, int typeID) {

            TowerEntity entity = GameFactory.Tower_Create(ctx, typeID);

            ctx.towerRepository.Add(entity);
            return entity;
        }

        public static void TearDown(GameContext ctx, TowerEntity entity) {
            ctx.towerRepository.Remove(entity);
            entity.TearDown();
        }

    }
}