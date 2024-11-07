using System;
using UnityEngine;

namespace TD {

    public static class UserInteractDomain {

        public static void Tick(GameContext ctx) {
            var input = ctx.inputEntity;

            var game = ctx.gameEntity;
            var handleTower = game.handTower;

            // === Select ====

            // ==== Build ====
            if (handleTower != null) {
                if (input.mouseLeftClick) {
                    Tower_TryBuild(ctx, handleTower.typeID, input.mousePositionGrid);
                }
            }
        }

        static void Tower_TryBuild(GameContext ctx, int typeID, Vector2Int pos) {

            bool allow = Tower_AllowBuild(ctx, typeID, pos);
            if (!allow) {
                // TODO: UI notice
                return;
            }

            Tower_Build(ctx, typeID, pos);

        }

        public static void Tower_Build(GameContext ctx, int typeID, Vector2Int pos) {
            var tower = TowerDoamin.Spawn(ctx, typeID, pos);

            GameObject.Destroy(ctx.gameEntity.handTower.gameObject);
            ctx.gameEntity.handTower = null;

            Debug.Log("建造成功");
        }

        static bool Tower_AllowBuild(GameContext ctx, int typeID, Vector2Int pos) {
            // 没有这个塔
            bool has = ctx.templateCore.ctx.Tower_TryGet(typeID, out TowerTM tm);
            if (!has) {
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
                    return true;
                } else {
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

        public static void Tower_Build(GameContext ctx) {

            var game = ctx.gameEntity;
            var handleTower = game.handTower;
            if (handleTower == null) {
                return;
            }

            if (ctx.inputEntity.mouseLeftClick && handleTower.typeID == TowerConst.ArrowTower) {
                handleTower.SetPos(ctx.inputEntity.mousePositionGrid);
                handleTower.isLive = true;
                game.handTower = null;
            }

            if (handleTower == null) {
                return;
            }

            if (ctx.inputEntity.mouseLeftClick && handleTower.typeID == TowerConst.TreeTower) {

                // 如果有这个位置的树
                Vector2Int pos = ctx.inputEntity.mousePositionGrid;
                if (ctx.treeRepository.IsPosHas(pos)) {

                    TreeEntity treeEntity = ctx.treeRepository.FindByPos(pos);

                    Vector3 towerPos = new Vector3(pos.x, pos.y, 0);
                    foreach (Vector2Int pos2 in ctx.treeRepository.posDict.Keys) {
                        Debug.Log(pos2);
                    }

                    Debug.Log("鼠标坐标" + pos);
                    handleTower.SetPos(pos);
                    handleTower.isLive = true;
                    game.handTower = null;

                }
            }
        }

    }
}