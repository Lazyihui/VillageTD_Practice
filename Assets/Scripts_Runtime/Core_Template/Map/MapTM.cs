using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TD {

    [Serializable]

    public class MapTM {
        public int typeID;
        public GameObject prefab;
        public HashSet<Vector2Int> treePos;
        public Tile treeTile;       
    }

}