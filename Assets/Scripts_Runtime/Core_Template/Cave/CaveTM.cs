using System;
using UnityEngine;


namespace TD {

    [Serializable]
    public class CaveTM {

        public int typeID;

        public float caveSpawnTime;
        public float caveSpawnInterval;

        public bool isLive;
        public float activeTimer;
        public float activeInterval;

        public int spawnMaxCount;
    }
}