using System;
using UnityEngine;

namespace TD {

    public static class UserInteractDomain {

        public static void Tick(GameContext ctx, float dt) {
            var input = ctx.inputEntity;

            var game = ctx.gameEntity;
            // === Select ====

            // ==== Build ====
            bool handhasCard = game.handHasCard;
            if (handhasCard) {
                if (input.mouseLeftClick) {
                    int typeID = ctx.gameEntity.handCardID;
                    Tower_TryBuild(ctx, typeID, input.mousePositionGrid);
                }
            }

            // ==== 种树 ====
            bool hasTreeCard = game.handHasCardTree;
            if (hasTreeCard) {
                if (input.mouseLeftClick) {

                    int typeID = ctx.gameEntity.handCardID;
                    Tree_TryBuild(ctx, typeID, input.mousePositionGrid);
                }
            }

            // ==== 拆塔 ====

            // ==== 升级 ====

            // ==== 卖塔 ====

            // ==== 选中 ====
            ShowPanel_TowerInfo(ctx);
            OpenPanel_TowerInfoa(ctx);
            OpenPanel_PanelInfo(ctx);

            // ==== 关闭引导 ====
            ClosePanel_Guide(ctx, dt);

            // ==== 关闭提示 ====
            ClosePanel_Notice(ctx, dt);
        }

        #region BuildTower
        static void Tree_TryBuild(GameContext ctx, int typeID, Vector2Int pos) {
            bool allow = Tower_AllowBuild(ctx, typeID, pos);
            if (!allow) {
                // TODO: UI notice
                return;
            }

            Tree_Plant(ctx, pos);
        }
        static void Tower_TryBuild(GameContext ctx, int typeID, Vector2Int pos) {

            bool allow = Tower_AllowBuild(ctx, typeID, pos);
            if (!allow) {
                // TODO: UI notice
                return;
            }
            Debug.Log("允许建塔");
            Tower_Bulid(ctx, typeID, pos);
        }

        public static void Tower_Bulid(GameContext ctx, int typeID, Vector2Int pos) {
            MapEntity mapEntity = ctx.mapRepository.GetMapByMousePos(pos);
            TowerEntity tower = TowerDomain.Spawn(ctx, typeID, pos, mapEntity.idSig);
            ctx.gameEntity.resCount -= tower.buildCost;

            ctx.appUI.Panel_SelectCard_Close();
            ctx.gameEntity.handHasCard = false;
            ctx.gameEntity.handCardID = -1;
        }

        public static void Tree_Plant(GameContext ctx, Vector2Int pos) {

            MapEntity mapEntity = ctx.mapRepository.GetMapByMousePos(pos);
            // TODO: TypeID的问题
            MapDomain.SetTile(ctx, mapEntity.treeGrid.tilemap, 1, pos);

            TreeDomain.Spawn(ctx, pos, 1, mapEntity.idSig);

            ctx.appUI.Panel_SelectCard_Close();
            ctx.gameEntity.handHasCardTree = false;
            ctx.gameEntity.handCardID = -1;

        }
        static bool Tower_AllowBuild(GameContext ctx, int typeID, Vector2Int pos) {
            // 没有这个塔
            bool has = ctx.templateCore.Tower_TryGet(typeID, out TowerTM tm);
            if (!has) {
                Debug.Log("没有这个typeID" + typeID);
                return false;
            }
            // 此处有塔
            bool hasTower = ctx.towerRepository.TryGetByPos(pos, out _);
            if (hasTower) {
                Debug.Log("此处有塔" + pos);
                return false;
            }
            bool hasTree = ctx.treeRepository.IsPosHas(pos);
            bool isLand = true;
            PlaceConditionType placeConditionType = tm.placeConditionType;
            // ==== Only ====
            // 0110 == 0100
            // 只能建在树上
            if (placeConditionType == PlaceConditionType.Tree) {
                if (hasTree /*but has no others*/) {
                    Debug.Log("这里有树可以建造");
                    return true;
                } else {
                    Debug.Log("没有树不可以建造");
                    return false;
                }
            }
            if (placeConditionType == PlaceConditionType.Land) {
                if (isLand && !hasTree) {
                    return true;
                } else {
                    return false;
                }
            }
            // TODO: 只能造水池
            // ==== Or ====
            // 0110 & 0100 != 0
            // 允许建在树上
            if (placeConditionType.HasFlag(PlaceConditionType.Tree)) {
                if (hasTree) {
                    return true;
                }
            }

            // TODO: 允许建在水池

            if (placeConditionType.HasFlag(PlaceConditionType.Land)) {
                if (isLand) {
                    return true;
                }
            }
            return false;

        }
        #endregion
        #region  panel_Info
        // 鼠标和塔交互 鼠标是否在塔上
        public static bool MousePosInteractTower(GameContext ctx) {
            InputEntity input = ctx.inputEntity;
            int len = ctx.towerRepository.TakeAll(out TowerEntity[] towers);
            for (int i = 0; i < len; i++) {
                TowerEntity tower = towers[i];
                float distance = Vector2.Distance(tower.transform.position, ctx.inputEntity.mousePositionWorld);
                if (distance < 0.5f) {
                    ctx.gameEntity.mouseTowerIDSig = tower.idSig;
                    return true;
                }
            }
            return false;
        }

        public static bool MousePosInteractPanel(GameContext ctx) {
            InputEntity input = ctx.inputEntity;

            int len = ctx.appUI.TakeAll_ManifastElement(out Panel_ManifastElement[] panels);
            for (int i = 0; i < len; i++) {
                Panel_ManifastElement panel = panels[i];
                float distance = Vector2.Distance(panel.transform.position, ctx.inputEntity.mousePositionScreen);
                if (distance < 19f) {
                    ctx.gameEntity.mousePanelIDSig = panel.idSig;
                    ctx.gameEntity.MousePaneltypeID = panel.typeID;
                    return true;
                }
            }

            return false;

        }
        // 显示Panel
        public static void ShowPanel_TowerInfo(GameContext ctx) {
            var game = ctx.gameEntity;
            var input = ctx.inputEntity;
            bool has = MousePosInteractTower(ctx);
            if (has) {
                ctx.towerRepository.TryGet(game.mouseTowerIDSig, out TowerEntity tower);
                ctx.appUI.Panel_TowerInfo_Open(input.mousePositionWorld, tower);
                ctx.appUI.Panel_TowerInfo_SetBtnActive(false);
            } else {
                if (game.isTowerInfoCanInteractmouse) {
                    ctx.appUI.Panel_TowerInfo_Close();
                }

            }
        }
        // 打开Panel
        public static void OpenPanel_TowerInfoa(GameContext ctx) {
            var game = ctx.gameEntity;
            InputEntity input = ctx.inputEntity;
            if (game.interactTowerIDSig == null) {
                return;
            }
            if (!game.isHUD_InteractPopupOpen) {
                return;
            }
            if (input.ispressF) {
                ctx.towerRepository.TryGet(game.interactTowerIDSig, out TowerEntity tower);
                Vector3 pos = new Vector3(tower.transform.position.x, tower.transform.position.y + 1.2f, 0);
                ctx.appUI.Panel_TowerInfo_Open(pos, tower);
                ctx.appUI.Panel_TowerInfo_SetBtnActive(true);
                game.isHUD_InteractPopupOpen = false;
                game.isTowerInfoCanInteractmouse = false;

            }
        }
        public static void OpenPanel_PanelInfo(GameContext ctx) {
            bool has = MousePosInteractPanel(ctx);
            if (has) {
                ctx.appUI.Panel_ManifastInfo_Open();
                ctx.templateCore.PanelCard_TryGet(ctx.gameEntity.MousePaneltypeID, out PanelCardTM tm);
                ctx.appUI.Panel_ManifastInfo_SetTxt(tm.typeName, tm.hp, tm.attack, tm.buildCost);
            } else {
                ctx.appUI.Panel_ManifastInfo_Close();
            }
        }

        #endregion


        #region  ClosePanel  
        // 根据时间来关闭引导
        public static void ClosePanel_Guide(GameContext ctx, float dt) {
            InputEntity input = ctx.inputEntity;
            var game = ctx.gameEntity;
            if (input.moveAxis != Vector2.zero) {
                game.panel_GuideCloseTimer -= dt;
                if (game.panel_GuideCloseTimer <= 0) {
                    ctx.appUI.Panel_Guide_Close();
                }
            }
        }
        public static void ClosePanel_Notice(GameContext ctx, float dt) {
            var game = ctx.gameEntity;
            if (game.isPanel_NoticeOpen) {
                game.panel_NoticeCloseTimer -= dt;
                if (game.panel_NoticeCloseTimer <= 0) {
                    ctx.appUI.Panel_Notice_Close();
                    ctx.gameEntity.isPanel_NoticeOpen = false;
                    game.panel_NoticeCloseTimer = 2;
                }
            }
        }
        #endregion


    }
}