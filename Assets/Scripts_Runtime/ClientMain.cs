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
                ctx.gameEntity.state = GameState.Game;
            };


            eventCenter.OnMainfastClickHandle += (int typeID) => {

                ctx.templateCore.PanelCard_TryGet(typeID, out PanelCardTM tm);
                int cost = tm.buildCost;
                if (ctx.gameEntity.resCount < cost) {
                    ctx.appUI.Panel_Notice_Open();
                    return;
                }

                ctx.appUI.Panel_SelectCard_Open(typeID);
                ctx.gameEntity.handHasCard = true;
                ctx.gameEntity.handCardID = typeID;
                Debug.Log("OnMainfastClickHandle: " + typeID);

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
