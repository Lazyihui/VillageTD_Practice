using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {


    public class CaveEntity : MonoBehaviour {
        public int typeID;

        public int id;


        public float caveSpawnTime;

        public float caveSpawnInterval;



        public void Ctor() {
            
        }


        public void SetPos(Vector3 pos) {
            transform.position = pos;
        }

    }
}