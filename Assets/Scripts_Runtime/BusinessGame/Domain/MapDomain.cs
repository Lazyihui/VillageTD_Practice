using System;
using System.Collections;
using System.Collections.Generic;
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

        public static HashSet<Vector2Int> GetTilePos(Tilemap tile) {
            var bound = tile.cellBounds;
            var tilePosHashSet = new HashSet<Vector2Int>();
            foreach (var pos in bound.allPositionsWithin) {

                var sprite = tile.GetSprite(pos);
                if (sprite != null) {
                    Vector2Int tilepos = new Vector2Int(pos.x, pos.y);
                    tilePosHashSet.Add(tilepos);
                    }
                // tilePosHashSet.Add(new Vector2Int(pos.x, pos.y));
            }

            return tilePosHashSet;
        }
    }
}