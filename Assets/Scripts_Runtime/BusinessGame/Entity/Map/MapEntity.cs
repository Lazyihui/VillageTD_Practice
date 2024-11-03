using System;
using UnityEngine;


namespace TD{

    public class MapEntity : MonoBehaviour{
        
        public int stageID;

        MapGripElement mapGripElement;

        public void Ctor(){

        }

        public void Inject(MapGripElement mapGripElement){
            this.mapGripElement = mapGripElement;
        }
        
    }
}