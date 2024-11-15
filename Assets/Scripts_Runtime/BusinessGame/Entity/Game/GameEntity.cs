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
        // 标记鼠标碰到panel
        public IDSignature mousePanelIDSig;

        public int MousePaneltypeID;
        public bool isMstOver;

        // panel_Guide的关闭时间
        public float panelCloseTimer;

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
            isMstOver = false;

            resCount = 500;

            handCardID = -1;
            MousePaneltypeID = -1;

            panelCloseTimer = 5;


        }
    }
}