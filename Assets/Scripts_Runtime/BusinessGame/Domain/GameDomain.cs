using System;
using UnityEngine;


namespace TD {


    public static class GameDomain {
        public static void SetTowerPos(GameContext ctx) {
            if (ctx.gameEntity.handTower == null) {
                return;
            }

            Vector3 pos = new Vector3(ctx.inputEntity.mousePositionGrid.x, ctx.inputEntity.mousePositionGrid.y, 0);
            ctx.gameEntity.handTower.SetPos(pos);
        }


        public static void BulidTowerArraw(GameContext ctx) {
            if (ctx.gameEntity.handTower == null) {
                return;
            }

            if (ctx.inputEntity.mouseLeftClick && ctx.gameEntity.handTower.typeID == TowerConst.ArrowTower) {

                Vector3 pos = new Vector3(ctx.inputEntity.mousePositionGrid.x, ctx.inputEntity.mousePositionGrid.y, 0);
                ctx.gameEntity.handTower.SetPos(pos);
                ctx.gameEntity.handTower.isLive = true;
                ctx.gameEntity.handTower = null;
            }

        }
        public static void BulidTowerTree(GameContext ctx) {

            if (ctx.gameEntity.handTower == null) {
                return;
            }

            if (ctx.inputEntity.mouseLeftClick && ctx.gameEntity.handTower.typeID == TowerConst.TreeTower) {

                // 如果有这个位置的树
                Vector2Int pos = ctx.inputEntity.mousePositionGrid;
                if (ctx.treeRepository.IsPosHas(pos)) {
                    TreeEntity treeEntity = ctx.treeRepository.FindByPos(pos);

                    Vector3 towerPos = new Vector3(pos.x, pos.y, 0);
                    ctx.gameEntity.handTower.SetPos(towerPos);
                    ctx.gameEntity.handTower.isLive = true;
                    ctx.gameEntity.handTower = null;

                } else {

                    Debug.Log("Can't build tower here" + pos);
                    foreach (Vector2Int treePos in ctx.treeRepository.posDict.Keys) {
                        Debug.Log("Tree pos: " + treePos);

                    }
                    // Debug.Log("Can't build tower here" + pos);

                    // foreach (Vector2Int treePos in ctx.gameEntity.treePosHashSet) {
                    //     Debug.Log("Tree pos: " + treePos);

                    // }                    
                }
            }

        }
        public static void CancelBulidTower(GameContext ctx) {
            if (ctx.gameEntity.handTower == null) {
                return;
            }

            if (ctx.inputEntity.mouseRightClick) {
                TowerDoamin.UnSpawn(ctx, ctx.gameEntity.handTower);
                ctx.gameEntity.handTower = null;
            }
        }


    }
}