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
            // ctx.assetsCore.LoadAll().ContinueWith((task) => {
            //     isInit = true;
            // });
            Action action = async () => {
                await ctx.assetsCore.LoadAll();
                isInit = true;
                // Login

            };

            Debug.Log("Start Loading Assets");
        }

        void Binding() {


        }




        void Update() {
            float dt = Time.deltaTime;


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
