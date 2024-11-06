using System;
using UnityEngine;


namespace TD {


    public class GameEntity {

        public float restFixTime;

        public int ownerID;

        public int towerRecordID;

        public int stageID;

        public int treeRecordID;

        public int mstroleRecordID;

        public int bulletRecordID;

        public GameState state;

        public TowerEntity handTower;


        //  暂时这样写  后面用Cave代替
        public float caveSpawnTime;

        public float caveSpawnInterval;

        public GameEntity() {
            restFixTime = 0;
            ownerID = 0;
            towerRecordID = 0;
            stageID = 0;
            treeRecordID = 0;
            mstroleRecordID = 0;
            bulletRecordID = 0;

            state = GameState.Login;

            handTower = null;


            caveSpawnTime = 0;
            caveSpawnInterval = 4;
        }
    }
}