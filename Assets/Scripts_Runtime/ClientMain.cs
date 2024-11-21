using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace TD {

    public class ClientMain : MonoBehaviour {

        GameContext ctx;
        [SerializeField] Camera mainCamera;

        bool isTearDown = false;

        bool isInit = false;
        void Awake() {

            ctx = new GameContext();
            Canvas screenCanvas = GameObject.Find("ScreenCanvas").GetComponent<Canvas>();
            Canvas worldCanvas = GameObject.Find("WorldCanvas").GetComponent<Canvas>();

            Binding();

            ctx.InJect(screenCanvas, mainCamera, worldCanvas);
            Action action = async () => {

                await ctx.assetsCore.LoadAll();
                await ctx.templateCore.LoadAll(ctx);

                isInit = true;

                Logic_Business.Enter(ctx);
                // GameEnter;
            };

            action.Invoke();

        }
        #region  Binding
        void Binding() {
            var eventCenter = ctx.appUI.eventCenter;

            eventCenter.OnLoginClickHandle += () => {
                ctx.appUI.Panel_Login_Close();

                ctx.appUI.Panel_StageSelection_Open();
                ctx.appUI.Panel_StageSelection_AddElement(1, "第一关");
                ctx.appUI.Panel_StageSelection_AddElement(2, "第二关");

            };

            eventCenter.OnStageElementBtnClickHandle += (int stageID) => {

                ctx.gameEntity.stageID = stageID;
                ctx.appUI.Panel_StageSelection_Close();
                Game_Business.Enter(ctx);

            };


            eventCenter.OnMainfastClickHandle += (int typeID) => {
                var game = ctx.gameEntity;
                ctx.templateCore.PanelCard_TryGet(typeID, out PanelCardTM tm);
                int cost = tm.buildCost;
                if (game.resCount < cost) {
                    game.isPanel_NoticeOpen = ctx.appUI.Panel_Notice_Open();
                    return;
                }

                if (tm.isPlantTree) {
                    ctx.appUI.Panel_SelectCard_Open(typeID);
                    game.handHasCardTree = true;
                    game.handCardID = typeID;
                    Debug.Log("OnMainfastClickHandle:种树 " + typeID);

                } else {
                    ctx.appUI.Panel_SelectCard_Open(typeID);
                    game.handHasCard = true;
                    game.handCardID = typeID;
                    Debug.Log("OnMainfastClickHandle:造塔" + typeID);
                }

            };

            eventCenter.OnRestartFailClickHandle += () => {
                ctx.appUI.Panel_Fail_Close();
                Game_Business.Enter(ctx);
            };

            eventCenter.OnRestartVictoryClickHandle += () => {
                ctx.appUI.Panel_Victory_Close();
                Game_Business.Enter(ctx);
            };

            eventCenter.OnNextClickHandle += () => {
                ctx.gameEntity.stageID++;
                Game_Business.Enter(ctx);
                ctx.appUI.Panel_Victory_Close();
            };

            eventCenter.OnRemoveClickTowerHandle += () => {
                Debug.Log("OnRemoveClickTowerHandle");
            };

            eventCenter.OnUpgradeClickTowerHandle += () => {
                Debug.Log("OnUpgradeClickTowerHandle");
            };

            eventCenter.OnCloseClickTowerHandle += () => {
                ctx.appUI.Panel_TowerInfo_Close();
                ctx.gameEntity.isTowerInfoCanInteractmouse = true;
            };

        }
        #endregion
        void OnGUI() {
            GUILayout.Label("Mouse World Pos: " + ctx.inputEntity.mousePositionWorld);
            GUILayout.Label("Mouse Grid Pos: " + ctx.inputEntity.mousePositionGrid);


        }

        void Update() {




            if (!isInit) {
                return;
            }
            float dt = Time.deltaTime;
            var game = ctx.gameEntity;
            ctx.inputEntity.Process(dt);


            if (game.state == GameState.Login) {

            } else if (game.state == GameState.Game) {
                Game_Business.Tick(ctx, dt);
            }

        }

        void OnDestroy() {
            TearDown();
        }

        void OnApplicationQuit() {
            TearDown();
        }

        void TearDown() {
            if (isTearDown) {
                return;
            }

            isTearDown = true;

            ctx.assetsCore.UnLoadAll();
            ctx.templateCore.UnLoadAll();
        }
    }
}
