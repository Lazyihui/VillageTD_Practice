using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;


namespace TD {

    [ExecuteInEditMode]
    public class MapEM : MonoBehaviour {

        public MapSO mapSo;

        public Tilemap treeTilemap;

        void Update() {
            var so = mapSo;
            if (so == null) {
                return;
            }
            var tm = so.tm;

        }

        [ContextMenu("Save")]
        public void Save() {
            // 保存地图prefab

            // 保存树的坐标
            mapSo.tm.treePos = GetTilePos(treeTilemap);
            foreach (Vector2Int pos in mapSo.tm.treePos) {
                Debug.Log(pos);
            }
        }

        public HashSet<Vector2Int> GetTilePos(Tilemap tile) {
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

    }
}