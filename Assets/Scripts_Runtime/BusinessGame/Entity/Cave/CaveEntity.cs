using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {


    public class CaveEntity {
        public int typeID;

        public int id;


        public float caveSpawnTime;

        public float caveSpawnInterval;

        

        public CaveEntity() {
            caveSpawnTime = 0;
            caveSpawnInterval = 4;
        }

    }
}