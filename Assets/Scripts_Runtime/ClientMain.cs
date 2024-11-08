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

            Canvas worldCanvas = GameObject.Find("WorldCanvas").GetComponent<Canvas>();


            ctx.InJect(screenCanvas, mainCamera, worldCanvas);
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

            eventCenter.OnHatChetClickHandle += (int typeID) => {
                // 可以直接写成函数
                ctx.gameEntity.handHasCard = true;
                ctx.gameEntity.handCardID = typeID;
                ctx.appUI.Panel_SelectCard_Open(ctx, typeID);

            };

            eventCenter.OnTowerClickHandle += (int typeID) => {

                ctx.gameEntity.handHasCard = true;
                ctx.gameEntity.handCardID = typeID;
                ctx.appUI.Panel_SelectCard_Open(ctx, typeID);
            };

            eventCenter.OnPlantTreeClickHandle += (int typeID) => {

                ctx.gameEntity.handHasCardTree = true;
                ctx.gameEntity.handCardID = typeID;
                ctx.appUI.Panel_SelectCard_Open(ctx, typeID);

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
