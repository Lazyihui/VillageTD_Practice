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
                Debug.Log("生成树塔 砍树");
                Debug.Log(typeID);
                // ctx.gameEntity.handTower = GameFactory.Tower_Create(ctx, typeID, Vector2Int.zero);

                ctx.gameEntity.isHandHasCard = true;

                ctx.appUI.Panel_SelectCard_Open(ctx, typeID);

            };

            eventCenter.OnTowerClickHandle += (int typeID) => {

                ctx.gameEntity.isHandHasCard = true;
                ctx.appUI.Panel_SelectCard_Open(ctx, typeID);


                // Debug.Log("打开塔面板");
                // ctx.gameEntity.handTower = GameFactory.Tower_Create(ctx, typeID, Vector2Int.zero);
                // Debug.Log(typeID);
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
