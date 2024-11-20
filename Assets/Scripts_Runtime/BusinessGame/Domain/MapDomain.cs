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
        public static void UnSpawn(GameContext ctx, MapEntity entity) {
            ctx.mapRepository.Remove(entity);
            entity.TearDown();
        }

        // public static HashSet<Vector2Int> GetTilePos(Tilemap tile) {
        //     BoundsInt bound = tile.cellBounds;
        //     HashSet<Vector2Int> tilePosHashSet = new HashSet<Vector2Int>();

        //     foreach (Vector3Int pos in bound.allPositionsWithin) {
        //         Sprite sprite = tile.GetSprite(pos);
        //         if (sprite != null) {
        //             Vector2Int tilepos = new Vector2Int(pos.x, pos.y);
        //             tilePosHashSet.Add(tilepos);
        //         }
        //     }
        //     return tilePosHashSet;
        // }

        public static void SetTile(GameContext ctx, Tilemap tilemap, int typeID, Vector2Int pos) {
            bool has = ctx.templateCore.Tree_TryGet(typeID, out TreeTM tm);
            if (!has) {
                Debug.LogError("SetTile Tree_TryGet Error");
                return;
            }
            // TODO: 要用新的InputEntity
            if (Input.GetMouseButtonDown(0)) {
                Vector3Int posCell = new Vector3Int(ctx.inputEntity.mousePositionGrid.x, ctx.inputEntity.mousePositionGrid.y, 0);
                tilemap.SetTile(posCell, tm.treeTile);
            }
        }


        public static void DeleteCells(GameContext ctx, MapEntity map, Vector3Int pos) {
            // 格子位置和格子的大小
            Tilemap tilemap = map.treeGrid.tilemap;
            tilemap.SetTile(pos, null);

        }


        public static void Clear(GameContext ctx) {
            int len = ctx.mapRepository.TakeAll(out MapEntity[] maps);
            for (int i = 0; i < len; i++) {
                MapEntity map = maps[i];
                UnSpawn(ctx, map);
            }
        }

    }
}