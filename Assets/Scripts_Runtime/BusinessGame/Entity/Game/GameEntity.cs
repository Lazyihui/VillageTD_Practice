using System;
using System.Collections.Generic;
using UnityEngine;


namespace TD {


    public class GameEntity {
        // 关卡ID
        public int stageID;

        public float restFixTime;

        public IDSignature ownerIDSig; // ulong

        public int towerRecordID;

        public int stageRecordID;

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
        public bool isCavrSpawnMstOver;

        // panel_Guide的关闭时间
        public float panel_GuideCloseTimer;

        public float panel_NoticeCloseTimer;

        public GameEntity() {

            stageID = 1;


            restFixTime = 0;
            towerRecordID = 0;
            stageRecordID = 0;
            treeRecordID = 0;
            mstroleRecordID = 0;
            bulletRecordID = 0;
            caveRecordID = 0;

            state = GameState.None;

            handHasCard = false;
            handHasCardTree = false;
            isCavrSpawnMstOver = false;

            resCount = 500;

            handCardID = -1;
            MousePaneltypeID = -1;

            panel_GuideCloseTimer = 5;

            panel_NoticeCloseTimer = 2;

        }

        public void Ctor() {

            restFixTime = 0;
            
            towerRecordID = 0;
            stageRecordID = 0;
            treeRecordID = 0;
            mstroleRecordID = 0;
            bulletRecordID = 0;
            caveRecordID = 0;

            state = GameState.None;

            handHasCard = false;
            handHasCardTree = false;
            isCavrSpawnMstOver = false;

            resCount = 500;

            handCardID = -1;
            MousePaneltypeID = -1;

            panel_GuideCloseTimer = 5;

            panel_NoticeCloseTimer = 2;
        }
    }
}