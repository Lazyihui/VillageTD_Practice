using System;
using UnityEngine;


namespace TD {

    public class MapEntity : MonoBehaviour {
        

        public IDSignature idSig;

          MapGripElement groundTile;

        public MapGripElement treeGrid;

        public void Ctor() {

        }

        public void Inject(MapGripElement ground, MapGripElement tree) {
            this.groundTile = ground;
            this.treeGrid = tree;
        }

    }
}