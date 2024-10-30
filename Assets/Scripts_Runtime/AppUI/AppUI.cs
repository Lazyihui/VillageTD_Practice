using System;
using System.Collections.Generic;
using UnityEngine;


namespace TD {

    public class AppUI {

        UIContext ctx;

        public UIEventCenter eventCenter;

        public AppUI() {
            ctx = new UIContext();
            eventCenter = new UIEventCenter();
        }

        public void Panel_Login_Open(GameContext ctx) {
            Panel_Login panel = ctx.appUI.ctx.panel_Login;

            if (panel == null) {

                GameObject prefab = ctx.assetsCore.Panel_GetLogin();

                GameObject go = GameObject.Instantiate(prefab, ctx.screenCanvas.transform);
                panel = go.GetComponent<Panel_Login>();

                panel.Ctor();

                panel.OnLoginClick += () => {

                    ctx.appUI.eventCenter.OnLoginClick();

                };

            }
            ctx.appUI.ctx.panel_Login = panel;
            panel.Show();

        }

        public void Panel_Login_Close(GameContext ctx) {
            Panel_Login panel = ctx.appUI.ctx.panel_Login;
            if(panel == null){
                return;
            }

            panel.TearDown();

        }

    }
}