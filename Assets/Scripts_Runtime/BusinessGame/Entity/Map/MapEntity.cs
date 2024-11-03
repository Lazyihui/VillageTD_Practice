using System;
using UnityEngine;


namespace TD{

    public class MapEntity : MonoBehaviour{

        public int stageID;

        MapGripElement groundTile;

        MapGripElement treeTile;

        public void Ctor(){

        }

        public void Inject(MapGripElement ground,MapGripElement tree){
            this.groundTile = ground;
            this.treeTile = tree;
        }
        
    }
}