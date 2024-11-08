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

                panel.OnHatChetClickHandle += (int typeID) => {
                    ctx.appUI.eventCenter.OnHatChetClick(typeID);
                };

                panel.OnTowerClickHandle += (int typeID) => {
                    ctx.appUI.eventCenter.OnTowerClick(typeID);
                };

                panel.OnPlantTreeClickHandle += (int typeID) => {
                    ctx.appUI.eventCenter.OnPlantTreeClick(typeID);
                };

            }
            ctx.appUI.ctx.panel_Manifast = panel;
            panel.Show();
        }

        public void panel_Manifast_Close(GameContext ctx) {
            Panel_Manifast panel = ctx.appUI.ctx.panel_Manifast;
            if (panel == null) {
                return;
            }

            panel.TearDown();
        }

        public void Panel_ResourceInfo_Open(GameContext ctx) {

            Panel_ResourceInfo panel = ctx.appUI.ctx.panel_ResourceInfo;

            if (panel == null) {
                GameObject prefab = ctx.assetsCore.Panel_GetResourceInfo();

                GameObject go = GameObject.Instantiate(prefab, ctx.screenCanvas.transform);
                panel = go.GetComponent<Panel_ResourceInfo>();
                panel.Ctor();
            }

            ctx.appUI.ctx.panel_ResourceInfo = panel;
            panel.Show();
        }

        public void Panel_ResourceInfo_UpateResCount(GameContext ctx) {

            Panel_ResourceInfo panel = ctx.appUI.ctx.panel_ResourceInfo;
            if (panel == null) {
                return;
            }

            panel.SetResCount(ctx.gameEntity.resCount);

        }

        public void Panel_ResourceInfo_Close(GameContext ctx) {
            Panel_ResourceInfo panel = ctx.appUI.ctx.panel_ResourceInfo;
            if (panel == null) {
                return;
            }

            panel.TearDown();
        }

        // Panel_SelectCard


        public void Panel_SelectCard_Open(GameContext ctx, int typeID) {
            Panel_SelectCard panel = ctx.appUI.ctx.panel_SelectCard;
            if (panel == null) {
                GameObject prefab = ctx.assetsCore.Panel_GetSelectCard();

                GameObject go = GameObject.Instantiate(prefab, ctx.worldCanvas.transform);
                panel = go.GetComponent<Panel_SelectCard>();
                panel.Ctor();

                ctx.templateCore.ctx.PanelCard_TryGet(typeID, out PanelCardTM tm);
                panel.SetSprite(tm.sprite);

            }

            panel.Show();
            ctx.appUI.ctx.panel_SelectCard = panel;
        }

        public void Panel_SelectCard_SetPos(GameContext ctx, Vector2Int pos) {
            Panel_SelectCard panel = ctx.appUI.ctx.panel_SelectCard;

            if (panel == null) {
                return;
            }

            panel.SetPos(pos);

        }

        public void Panel_SelectCard_Close(GameContext ctx) {
            Panel_SelectCard panel = ctx.appUI.ctx.panel_SelectCard;
            if (panel == null) {
                return;
            }

            panel.TearDown();
        }


    }
}