using System;
using System.Collections;
using UnityEngine;


namespace TD {

    [Serializable]
    public class StageTM {

        public int typeID;

        public GameObject mapEntity;

        public RoleSpawnTM[] roleSpawnTMs;

        public CaveSpawnTM[] caveSpawnTMs;


    }
}