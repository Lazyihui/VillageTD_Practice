using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TD {


    public static class MapDomain {

        public static MapEntity Spawn(GameContext ctx, int typeID) {
            MapEntity entity = GameFactory.Map_Create(ctx, typeID);
            ctx.mapRepository.Add(entity);
            return entity;
        }

        public static void GetTileTreePos(MapGripElement treeTile, out Vector3Int pos) {
            treeTile.GetPos(out pos);

            Debug.Log("Tree pos: " + pos);

        }
    }
}