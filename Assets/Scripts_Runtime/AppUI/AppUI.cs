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

                panel.OnLoginClickHandle += () => {

                    ctx.appUI.eventCenter.OnLoginClick();

                };

            }
            ctx.appUI.ctx.panel_Login = panel;
            panel.Show();

        }

        public void Panel_Login_Close(GameContext ctx) {
            Panel_Login panel = ctx.appUI.ctx.panel_Login;
            if (panel == null) {
                return;
            }

            panel.TearDown();

        }

        public void Panel_Manifaset_Open(GameContext ctx) {
            Panel_Manifast panel = ctx.appUI.ctx.panel_Manifast;

            if (panel == null) {

                GameObject prefab = ctx.assetsCore.Panel_GetManifast();

                GameObject go = GameObject.Instantiate(prefab, ctx.screenCanvas.transform);
                panel = go.GetComponent<Panel_Manifast>();
                panel.Ctor();

                panel.OnHatChetClickHandle += () => {
                    ctx.appUI.eventCenter.OnHatChetClick();
                };

                panel.OnTowerClickHandle += () => {
                    ctx.appUI.eventCenter.OnTowerClick();
                };

            }
            ctx.appUI.ctx.panel_Manifast = panel;
            panel.Show();
        }

    }
}