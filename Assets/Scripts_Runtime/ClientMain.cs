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

            // Tilemap tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
            // TileBase tile = Resources.Load<TileBase>("Tilemap/Tilemap_1");
            // tilemap.SetTile(new Vector3Int(0, 0, 0), tile);

            ctx = new GameContext();
            Canvas screenCanvas = GameObject.Find("ScreenCanvas").GetComponent<Canvas>();

            ctx.InJect(screenCanvas, mainCamera);
            Action action = async () => {

                await ctx.assetsCore.LoadAll();
                await ctx.templateCore.LoadAll(ctx);

                isInit = true;

                Logic_Business.Enter(ctx);
                // GameEnter;
            };

            action.Invoke();

            Binding();
        }

        void Binding() {
            var eventCenter = ctx.appUI.eventCenter;

            eventCenter.OnLoginClickHandle += () => {
                ctx.appUI.Panel_Login_Close(ctx);
                Game_Business.Enter(ctx);
                ctx.gameEntity.state = GameState.Game;
            };

            eventCenter.OnHatChetClickHandle += () => {
                Debug.Log("打开斧头面板");
                Debug.Log("OnHatChetClickHandle");
            };



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
