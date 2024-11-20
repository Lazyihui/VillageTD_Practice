using System;
using System.Collections;
using UnityEngine;


namespace TD {

    [Serializable]
    public class StageTM {

        public int typeID;

        public GameObject mapEntity;

        public MapTM mapTM;

        public RoleSpawnTM[] roleSpawnTMs;

        public CaveSpawnTM[] caveSpawnTMs;

        public TowerSpawnTM[] towerSpawnTMs;


    }
}