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

        void Binding() {
            var eventCenter = ctx.appUI.eventCenter;

            eventCenter.OnLoginClickHandle += () => {
                ctx.appUI.Panel_Login_Close();
                Game_Business.Enter(ctx);
            };


            eventCenter.OnMainfastClickHandle += (int typeID) => {
                var game = ctx.gameEntity;

                ctx.templateCore.PanelCard_TryGet(typeID, out PanelCardTM tm);

                int cost = tm.buildCost;
                Debug.Log("OnMainfastClickHandle: " + typeID + " 金币不足" + cost);
                if (ctx.gameEntity.resCount < cost) {
                    game.isPanel_NoticeOpen = ctx.appUI.Panel_Notice_Open();
                    Debug.Log("OnMainfastClickHandle: " + typeID + " 金币不足");
                    return;
                }

                ctx.appUI.Panel_SelectCard_Open(typeID);
                ctx.gameEntity.handHasCard = true;
                ctx.gameEntity.handCardID = typeID;
                Debug.Log("OnMainfastClickHandle: " + typeID);

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

        }
        void OnGUI() {
            GUILayout.Label("Mouse World Pos: " + ctx.inputEntity.mousePositionWorld);
            GUILayout.Label("Mouse Grid Pos: " + ctx.inputEntity.mousePositionGrid);
        }

        void Update() {

            if (!isInit) {
                return;
            }
            float dt = Time.deltaTime;

            ctx.inputEntity.Process(dt);

            if (ctx.gameEntity.state == GameState.Login) {

            } else if (ctx.gameEntity.state == GameState.Game) {
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
