using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD {

    public class ClientMain : MonoBehaviour {

        GameContext ctx;

        bool isTearDown = false;

        bool isInit = false;
        void Awake() {

            ctx = new GameContext();
            Canvas screenCanvas = GameObject.Find("ScreenCanvas").GetComponent<Canvas>();

            ctx.InJect(screenCanvas);
            Action action = async () => {

                await ctx.assetsCore.LoadAll();

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
            };



        }




        void Update() {
            if (!isInit) {
                return;
            }
            float dt = Time.deltaTime;

            ctx.inputEntity.Process(dt);

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
        }
    }
}
