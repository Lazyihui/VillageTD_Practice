using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TD {

    public class MapGripElement : MonoBehaviour {
        public int typeID;

        public IDSignature idSignature;

        [SerializeField] public Tilemap tile;

        public void GetPos(out Vector3Int pos) {
            pos = tile.WorldToCell(transform.position);

            // pos = tile.WorldToLocal(transform.position);\

        }
    }
}