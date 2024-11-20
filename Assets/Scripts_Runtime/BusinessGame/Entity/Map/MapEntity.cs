using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD {

    public class MapEntity : MonoBehaviour {


        public IDSignature idSig;

        public MapGripElement groundTile;

        public MapGripElement treeGrid;

        public HashSet<Vector2Int> treePos;

        public void Ctor() {

        }

        public void TearDown() {
            Destroy(gameObject);
        }


    }
}