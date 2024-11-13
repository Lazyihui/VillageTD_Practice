using System;
using UnityEngine;

namespace TD {

    public static class UserInteractDomain {

        public static void Tick(GameContext ctx, float dt) {
            var input = ctx.inputEntity;

            var game = ctx.gameEntity;
            // === Select ====

            // ==== Build ====
            bool hasCard = game.handHasCard;
            if (hasCard) {
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
            OpenPanel_TowerInfo(ctx);

            // ==== 关闭引导 ====
            ClosePanel_Guide(ctx, dt);
        }

        #region BuildTower
        static void Tree_TryBuild(GameContext ctx, int typeID, Vector2Int pos) {
            bool allow = Tower_AllowBuild(ctx, typeID, pos);
            if (!allow) {
                // TODO: UI notice
                return;
            }

            Tree_Plant(ctx, typeID, pos);
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
            TowerEntity tower = TowerDoamin.Spawn(ctx, typeID, pos);
            ctx.gameEntity.resCount -= tower.buildCost;

            ctx.appUI.Panel_SelectCard_Close();
            ctx.gameEntity.handHasCard = false;
            ctx.gameEntity.handCardID = -1;
        }

        public static void Tree_Plant(GameContext ctx, int typeID, Vector2Int pos) {
            IDSignature idSig = new IDSignature(EntityType.Map, 0);
            // TODO: TypeID问题
            ctx.mapRepository.TryGet(idSig, out MapEntity mapEntity);


            MapDomain.SetTile(ctx, mapEntity.treeGrid.tile, 1, pos);

            TreeDomain.Spawn(ctx, pos, 1);

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
                    Debug.Log("这里有数可以种");
                    return true;
                } else {
                    Debug.Log("没有数不可以种");
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

            return false;

        }

        public static void OpenPanel_TowerInfo(GameContext ctx) {
            bool has = MousePosInteractTower(ctx);
            if (has) {
                ctx.appUI.Panel_TowerInfo_Open(ctx.inputEntity.mousePositionWorld);
                ctx.towerRepository.TryGet(ctx.gameEntity.mouseTowerIDSig, out TowerEntity tower);
                ctx.appUI.Panel_TowerInfo_SetTxt(tower.name, tower.hp, tower.attackHurt, tower.buildCost);
            } else {
                ctx.appUI.Panel_TowerInfo_Close();
            }
        }


        #endregion
        public static void ClosePanel_Guide(GameContext ctx, float dt) {
            InputEntity input = ctx.inputEntity;
            var game = ctx.gameEntity;

            if (input.moveAxis != Vector2.zero) {
                game.panelCloseTimer -= dt;
                if (game.panelCloseTimer <= 0) {
                    ctx.appUI.Panel_Guide_Close();
                }
            }
        }

    }
}