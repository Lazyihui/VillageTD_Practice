using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TD {


    public static class MapDomain {

        public static MapEntity Spawn(GameContext ctx, GameObject model) {
            MapEntity entity = GameFactory.Map_Create(ctx, model);
            ctx.mapRepository.Add(entity);
            return entity;
        }

        public static HashSet<Vector2Int> GetTilePos(Tilemap tile) {
            BoundsInt bound = tile.cellBounds;
            HashSet<Vector2Int> tilePosHashSet = new HashSet<Vector2Int>();

            foreach (Vector3Int pos in bound.allPositionsWithin) {
                Sprite sprite = tile.GetSprite(pos);

                if (sprite != null) {
                    Vector2Int tilepos = new Vector2Int(pos.x, pos.y);
                    tilePosHashSet.Add(tilepos);
                }
            }

            return tilePosHashSet;
        }

        public static void SetTile(GameContext ctx, Tilemap tilemap, int typeID, Vector2Int pos) {


            bool has = ctx.templateCore.ctx.Tree_TryGet(typeID, out TreeTM tm);
            if (!has) {
                Debug.LogError("SetTile Tree_TryGet Error");
                return;
            }

            if (Input.GetMouseButtonDown(0)) {

                Vector3Int posCell = new Vector3Int(ctx.inputEntity.mousePositionGrid.x, ctx.inputEntity.mousePositionGrid.y, 0);

                tilemap.SetTile(posCell, tm.treeTile);

            }


        }

    }
}