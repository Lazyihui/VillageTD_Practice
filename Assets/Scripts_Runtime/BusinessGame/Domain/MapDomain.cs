using System;
using UnityEngine;


namespace TD {


    public static class MapDomain {

        public static MapEntity Spawn(GameContext ctx, int typeID) {
            MapEntity entity = GameFactory.Map_Create(ctx, typeID);
            ctx.mapRepository.Add(entity);
            return entity;
        }
    }
}