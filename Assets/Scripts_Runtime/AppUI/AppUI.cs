using System;
using System.Collections.Generic;
using UnityEngine;
using TD.UIInternal;


namespace TD {

    public class AppUI {

        public UIContext ctx;

        public UIEventCenter eventCenter;


        public int manifastEleRecordID;

        public AppUI() {
            ctx = new UIContext();
            eventCenter = new UIEventCenter();

            manifastEleRecordID = 0;
        }

        public void Inject(AssetsCore assetsCore, TemplateCore templateCore, Canvas screenCanvas, Canvas worldCanvas) {
            ctx.Inject(assetsCore, templateCore, screenCanvas, worldCanvas);
        }

        public int TakeAll_ManifastElement(out Panel_ManifastElement[] array) {
            return ctx.panel_ManifasetElementRepos.TakeAll(out array);
        }

        //  public int TakeAll(out Panel_ManifastElement[] array) {
        //     if (all.Count > temArray.Length) {
        //         temArray = new Panel_ManifastElement[all.Count * 2];
        //     }
        //     all.Values.CopyTo(temArray, 0);
        //     array = temArray;
        //     return all.Count;
        // }


        #region Panel_Login
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
        #endregion

        #region Panel_Manifast
        public void Panel_Manifaset_Open() {
            Panel_Manifast panel = ctx.panel_Manifast;

            if (panel == null) {

                GameObject prefab = ctx.assetsCore.Panel_GetManifast();

                GameObject go = GameObject.Instantiate(prefab, ctx.screenCanvas.transform);
                panel = go.GetComponent<Panel_Manifast>();
                panel.Ctor();

            }
            ctx.panel_Manifast = panel;
            panel.Show();
        }


        public void Panel_Manifast_AddElement(int typeID) {
            Panel_Manifast panel = ctx.panel_Manifast;
            if (panel == null) {
                return;
            }

            ctx.templateCore.PanelCard_TryGet(typeID, out PanelCardTM tm);
            if (tm == null) {
                Debug.LogError("PanelCardTM not found" + typeID);
                return;
            }

            GameObject prefab = ctx.assetsCore.Panel_GetManifastElement();
            Panel_ManifastElement ele = GameObject.Instantiate(prefab, panel.group).GetComponent<Panel_ManifastElement>();

            ele.idSig.entityID = manifastEleRecordID++;
            ele.idSig.entityType = EntityType.ManifastElement;

            ele.resCount = tm.buildCost;
            ele.typeID = tm.typeID;
            ele.SetImage(tm.sprite);
            ele.SetT_xtCost(tm.buildCost);

            ele.OnClickHandle += (int typeID) => {
                eventCenter.OnMainfastClickElement(typeID);
            };

            ele.Ctor();

            ctx.panel_ManifasetElementRepos.Add(ele);

        }

        public void panel_Manifast_Close() {
            Panel_Manifast panel = ctx.panel_Manifast;
            if (panel == null) {
                return;
            }

            int len = ctx.panel_ManifasetElementRepos.TakeAll(out Panel_ManifastElement[] eles);
            for (int i = 0; i < len; i++) {
                Panel_ManifastElement ele = eles[i];
                ele.TearDown();
            }

            panel.TearDown();
        }
        #endregion

        #region Panel_ResourceInfo
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

        #endregion

        #region Panel_Select

        public void Panel_SelectCard_Open(int typeID) {
            Panel_SelectCard panel = ctx.panel_SelectCard;
            if (panel == null) {
                GameObject prefab = ctx.assetsCore.Panel_GetSelectCard();

                GameObject go = GameObject.Instantiate(prefab, ctx.worldCanvas.transform);
                panel = go.GetComponent<Panel_SelectCard>();
                panel.Ctor();

                ctx.templateCore.PanelCard_TryGet(typeID, out PanelCardTM tm);
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

        #endregion

        #region Panel_TowerInfo
        public void Panel_TowerInfo_Open(Vector3 pos, TowerEntity tower) {
            Panel_TowerInfo panel = ctx.panel_TowerInfo;
            if (panel == null) {
                GameObject prefab = ctx.assetsCore.Panel_GetTowerInfo();

                GameObject go = GameObject.Instantiate(prefab, ctx.worldCanvas.transform);
                panel = go.GetComponent<Panel_TowerInfo>();
                panel.Ctor();
                panel.OnRemoveClickHandle += () => {
                    eventCenter.OnRemoveBtnClickTower();
                };
                panel.OnUpgradeClickHandle += () => {
                    eventCenter.OnUpgradeBtnClickTower();
                };
                panel.OnCloseClickHandle += () => {
                    eventCenter.OnCloseBtnClickTower();
                };

                panel.SetPos(pos);
                panel.SetData(tower.name, tower.hp, tower.attackHurt, tower.buildCost);

            }

            panel.Show();
            ctx.panel_TowerInfo = panel;

        }

        public void Panel_TowerInfo_SetBtnActive(bool isActive) {
            Panel_TowerInfo panel = ctx.panel_TowerInfo;
            if (panel == null) {
                return;
            }

            panel.SetBtnActive(isActive);
        }
        public void Panel_TowerInfo_Close() {
            Panel_TowerInfo panel = ctx.panel_TowerInfo;
            if (panel == null) {
                return;
            }

            panel.TearDown();
        }
        #endregion

        #region Panel_Victory

        public void Panel_Victory_Open() {
            Panel_Victory panel = ctx.panel_Victory;
            if (panel == null) {
                GameObject prefab = ctx.assetsCore.Panel_Victory();

                GameObject go = GameObject.Instantiate(prefab, ctx.screenCanvas.transform);
                panel = go.GetComponent<Panel_Victory>();
                panel.Ctor();

                panel.OnRestartClickHandle += () => {
                    eventCenter.OnRestartVictoryClick();
                };

                panel.OnNextClickHandle += () => {
                    eventCenter.OnNextClick();
                };

            }

            panel.Show();
            ctx.panel_Victory = panel;
        }

        public void Panel_Victory_Close() {
            Panel_Victory panel = ctx.panel_Victory;
            if (panel == null) {
                return;
            }

            panel.TearDown();
        }

        # endregion

        #region Panel_Fail
        public void Panel_Fail_Open() {
            Panel_Fail panel = ctx.panel_Fail;
            if (panel == null) {
                GameObject prefab = ctx.assetsCore.Panel_GetFail();

                GameObject go = GameObject.Instantiate(prefab, ctx.screenCanvas.transform);
                panel = go.GetComponent<Panel_Fail>();
                panel.Ctor();

                panel.OnRestartClickHandle += () => {
                    eventCenter.OnRestartClick();
                };

            }

            panel.Show();
            ctx.panel_Fail = panel;
        }

        public void Panel_Fail_Close() {
            Panel_Fail panel = ctx.panel_Fail;
            if (panel == null) {
                return;
            }
            panel.TearDown();
        }


        #endregion

        #region Panel_Guide

        public void Panel_Guide_Open() {
            Panel_Guide panel = ctx.panel_Guide;
            if (panel == null) {
                GameObject prefab = ctx.assetsCore.Panel_GetGuide();

                GameObject go = GameObject.Instantiate(prefab, ctx.screenCanvas.transform);
                panel = go.GetComponent<Panel_Guide>();
                panel.Ctor();
            }

            panel.Show();
            ctx.panel_Guide = panel;
        }


        public void Panel_Guide_Close() {
            Panel_Guide panel = ctx.panel_Guide;
            if (panel == null) {
                return;
            }

            panel.TearDown();
        }

        #endregion


        #region Panel_ManifastInfo
        public void Panel_ManifastInfo_Open() {
            Panel_ManifastInfo panel = ctx.panel_ManifastInfo;
            if (panel == null) {
                GameObject prefab = ctx.assetsCore.Panel_GetGuidePanel();

                GameObject go = GameObject.Instantiate(prefab, ctx.worldCanvas.transform);
                panel = go.GetComponent<Panel_ManifastInfo>();
                panel.Ctor();
            }

            panel.Show();
            ctx.panel_ManifastInfo = panel;
        }


        public void Panel_ManifastInfo_SetTxt(string name, int hp, float attack, int cost) {

            Panel_ManifastInfo panel = ctx.panel_ManifastInfo;
            if (panel == null) {
                return;
            }
            panel.SetData(name, hp, attack, cost);

        }
        public void Panel_ManifastInfo_Close() {
            Panel_ManifastInfo panel = ctx.panel_ManifastInfo;
            if (panel == null) {
                return;
            }

            panel.TearDown();
        }


        #endregion

        #region Panel_Notice
        public bool Panel_Notice_Open() {
            Panel_Notice panel = ctx.panel_Notice;

            if (panel == null) {
                GameObject prefab = ctx.assetsCore.Panel_GetNotice();
                GameObject go = GameObject.Instantiate(prefab, ctx.screenCanvas.transform);
                panel = go.GetComponent<Panel_Notice>();
                panel.Ctor();
                Debug.Log("Panel_Notice_Open");
            }

            Debug.Log("Panel_Notice_Open");
            panel.Show();

            ctx.panel_Notice = panel;

            return true;
        }

        public void Panel_Notice_Close() {
            Panel_Notice panel = ctx.panel_Notice;
            if (panel == null) {
                return;
            }
            panel.TearDown();
        }
        #endregion

        #region Panel_StageSelection

        public void Panel_StageSelection_Open() {
            Panel_StageSelection panel = ctx.panel_StageSelection;
            if (panel == null) {
                GameObject prefab = ctx.assetsCore.Panel_GetStageSelection();

                GameObject go = GameObject.Instantiate(prefab, ctx.screenCanvas.transform);
                panel = go.GetComponent<Panel_StageSelection>();
                panel.Ctor();
            }

            panel.Show();
            ctx.panel_StageSelection = panel;
        }


        public void Panel_StageSelection_AddElement(int stageID, string stageIDName) {
            Panel_StageSelection panel = ctx.panel_StageSelection;
            if (panel == null) {
                return;
            }

            GameObject prefab = ctx.assetsCore.Panel_GetStageSelectionElement();
            Panel_StageSelectionElement ele = GameObject.Instantiate(prefab, panel.group).GetComponent<Panel_StageSelectionElement>();

            ele.stageID = stageID;
            ele.SetTxt(stageIDName);
            // ele.idSig.entityID = stageID;
            // ele.idSig.entityType = EntityType.StageElement;
            ele.OnBtnClickHandle += (int stageID) => {
                eventCenter.OnStageElementBtnClick(stageID);
            };
            ele.Ctor();
        }


        public void Panel_StageSelection_Close() {
            Panel_StageSelection panel = ctx.panel_StageSelection;
            if (panel == null) {
                return;
            }



            panel.TearDown();
        }


        #endregion

        #region HUD_GatherHint

        public void HUD_GatherHint_Open(IDSignature idSig) {
            ctx.hud_GatherHintRepos.TryGet(idSig, out HUD_GatherHint hudHint);
            if (hudHint != null) {
                return;
            }

            GameObject prefab = ctx.assetsCore.HUD_GetGatherHint();
            GameObject go = GameObject.Instantiate(prefab, ctx.worldCanvas.transform);
            HUD_GatherHint hud = go.GetComponent<HUD_GatherHint>();
            hud.Ctor();
            hud.idSig = idSig;
            Debug.Log("HUD_GatherHint_Open");
            ctx.hud_GatherHintRepos.Add(hud);

            hud.Show();

        }

        public void HUD_GatherHint_SetHint(float time, float allTime, IDSignature idSig) {
            ctx.hud_GatherHintRepos.TryGet(idSig, out HUD_GatherHint hud);
            if (hud == null) {
                return;
            }
            hud.SetHint(time, allTime);
        }

        public void HUD_GatherHint_SetPos(Vector3 pos, IDSignature idSig) {
            ctx.hud_GatherHintRepos.TryGet(idSig, out HUD_GatherHint hud);
            if (hud == null) {
                return;
            }
            hud.SetPos(pos);
        }

        public void HUD_GatherHint_Close(IDSignature idSig) {
            ctx.hud_GatherHintRepos.TryGet(idSig, out HUD_GatherHint hud);
            if (hud == null) {
                return;
            }
            hud.TearDown();
        }


        #endregion

        #region HUD_InteractPopup
        public void HUD_InteractPopup_Open(Vector3 pos) {
            HUD_InteractPopup hud = ctx.interactPopup;

            if (hud == null) {
                GameObject prefab = ctx.assetsCore.HUD_GetInteractPopup();
                GameObject go = GameObject.Instantiate(prefab, ctx.worldCanvas.transform);
                hud = go.GetComponent<HUD_InteractPopup>();
                hud.Ctor();

                hud.SetPos(pos);

            }


            hud.Show();
        }

        public Vector3 HUD_InteractPopup_GetPos() {
            HUD_InteractPopup hud = ctx.interactPopup;
            if (hud == null) {
                return Vector3.zero;
            }
            return hud.GetPos();
        }

        public void HUD_InteractPopup_Close() {
            HUD_InteractPopup hud = ctx.interactPopup;
            if (hud == null) {
                return;
            }

            hud.TearDown();
        }

        #endregion


        public void Clear() {
            panel_Manifast_Close();
            Panel_ResourceInfo_Close();
            Panel_Guide_Close();
            Panel_Login_Close();
            Panel_SelectCard_Close();
            Panel_Notice_Close();
            Panel_TowerInfo_Close();
            Panel_ManifastInfo_Close();

            ctx.panel_ManifasetElementRepos.Clear();

        }

    }
}