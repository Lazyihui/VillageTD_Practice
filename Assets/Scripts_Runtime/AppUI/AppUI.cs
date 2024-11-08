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

        public void Inject(AssetsCore assetsCore, TemplateCore templateCore, Canvas screenCanvas, Canvas worldCanvas) {
            ctx.Inject(assetsCore, templateCore, screenCanvas, worldCanvas);
        }


        public void Panel_Login_Open() {
            Panel_Login panel = ctx.panel_Login;

            if (panel == null) {

                GameObject prefab = ctx.assetsCore.Panel_GetLogin();

                GameObject go = GameObject.Instantiate(prefab, ctx.screenCanvas.transform);
                panel = go.GetComponent<Panel_Login>();

                panel.Ctor();

                panel.OnLoginClickHandle += () => {

                    eventCenter.OnLoginClick();

                };

            }
            ctx.panel_Login = panel;
            panel.Show();

        }

        public void Panel_Login_Close() {
            Panel_Login panel = ctx.panel_Login;
            if (panel == null) {
                return;
            }

            panel.TearDown();

        }

        public void Panel_Manifaset_Open() {
            Panel_Manifast panel = ctx.panel_Manifast;

            if (panel == null) {

                GameObject prefab = ctx.assetsCore.Panel_GetManifast();

                GameObject go = GameObject.Instantiate(prefab, ctx.screenCanvas.transform);
                panel = go.GetComponent<Panel_Manifast>();
                panel.Ctor();

                panel.OnHatChetClickHandle += (int typeID) => {
                    eventCenter.OnHatChetClick(typeID);
                };

                panel.OnTowerClickHandle += (int typeID) => {
                    eventCenter.OnTowerClick(typeID);
                };

                panel.OnPlantTreeClickHandle += (int typeID) => {
                    eventCenter.OnPlantTreeClick(typeID);
                };

            }
            ctx.panel_Manifast = panel;
            panel.Show();
        }

        public void panel_Manifast_Close() {
            Panel_Manifast panel = ctx.panel_Manifast;
            if (panel == null) {
                return;
            }

            panel.TearDown();
        }

        public void Panel_ResourceInfo_Open() {

            Panel_ResourceInfo panel = ctx.panel_ResourceInfo;

            if (panel == null) {
                GameObject prefab = ctx.assetsCore.Panel_GetResourceInfo();

                GameObject go = GameObject.Instantiate(prefab, ctx.screenCanvas.transform);
                panel = go.GetComponent<Panel_ResourceInfo>();
                panel.Ctor();
            }

            ctx.panel_ResourceInfo = panel;
            panel.Show();
        }

        public void Panel_ResourceInfo_UpateResCount(int resCount) {

            Panel_ResourceInfo panel = ctx.panel_ResourceInfo;
            if (panel == null) {
                return;
            }

            panel.SetResCount(resCount);

        }

        public void Panel_ResourceInfo_Close() {
            Panel_ResourceInfo panel = ctx.panel_ResourceInfo;
            if (panel == null) {
                return;
            }

            panel.TearDown();
        }

        // Panel_SelectCard


        public void Panel_SelectCard_Open(int typeID) {
            Panel_SelectCard panel = ctx.panel_SelectCard;
            if (panel == null) {
                GameObject prefab = ctx.assetsCore.Panel_GetSelectCard();

                GameObject go = GameObject.Instantiate(prefab, ctx.worldCanvas.transform);
                panel = go.GetComponent<Panel_SelectCard>();
                panel.Ctor();

                ctx.templateCore.ctx.PanelCard_TryGet(typeID, out PanelCardTM tm);
                panel.SetSprite(tm.sprite);

            }

            panel.Show();
            ctx.panel_SelectCard = panel;
        }

        public void Panel_SelectCard_SetPos(Vector2Int pos) {
            Panel_SelectCard panel = ctx.panel_SelectCard;

            if (panel == null) {
                return;
            }

            panel.SetPos(pos);

        }

        public void Panel_SelectCard_Close() {
            Panel_SelectCard panel = ctx.panel_SelectCard;
            if (panel == null) {
                return;
            }

            panel.TearDown();
        }


    }
}