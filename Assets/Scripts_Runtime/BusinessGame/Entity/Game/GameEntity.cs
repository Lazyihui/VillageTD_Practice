using System;
using System.Collections.Generic;
using UnityEngine;


namespace TD {


    public class GameEntity {

        public float restFixTime;

        public IDSignature ownerIDSig; // ulong

        public int towerRecordID;

        public int stageID;

        public int treeRecordID;

        public int mstroleRecordID;

        public int bulletRecordID;

        public int caveRecordID;

        public GameState state;


        public bool handHasCard;

        public bool handHasCardTree;

        public int handCardID;



        // 资源
        public int resCount;

        //  记录鼠标碰到的塔
        public IDSignature mouseTowerIDSig;

        public GameEntity() {
            restFixTime = 0;
            towerRecordID = 0;
            stageID = 0;
            treeRecordID = 0;
            mstroleRecordID = 0;
            bulletRecordID = 0;
            caveRecordID = 0;

            state = GameState.Login;

            handHasCard = false;
            handHasCardTree = false;

            resCount = 100;

            handCardID = -1;


        }
    }
}