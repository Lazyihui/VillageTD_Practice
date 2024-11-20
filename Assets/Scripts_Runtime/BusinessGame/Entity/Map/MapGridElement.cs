using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TD {

    public class MapGripElement : MonoBehaviour {
        public int typeID;

        public IDSignature idSignature;

        [SerializeField] public Tilemap tilemap;

        public void GetPos(out Vector3Int pos) {
            pos = tilemap.WorldToCell(transform.position);

            // pos = tile.WorldToLocal(transform.position);\

        }
    }
}