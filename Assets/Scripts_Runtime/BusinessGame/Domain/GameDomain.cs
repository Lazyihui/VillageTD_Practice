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


        public static void BulidTower(GameContext ctx) {
            if (ctx.gameEntity.handTower == null) {
                return;
            }

            if (ctx.inputEntity.mouseLeftClick && ctx.gameEntity.handTower.typeID == TowerConst.ArrowTower) {

                Vector3 pos = new Vector3(ctx.inputEntity.mousePositionGrid.x, ctx.inputEntity.mousePositionGrid.y, 0);
                ctx.gameEntity.handTower.SetPos(pos);
                ctx.gameEntity.handTower.isLive = true;
                ctx.gameEntity.handTower = null;
            }

            if (ctx.inputEntity.mouseLeftClick && ctx.gameEntity.handTower.typeID == TowerConst.TreeTower) {

                Vector3 pos = new Vector3(ctx.inputEntity.mousePositionGrid.x, ctx.inputEntity.mousePositionGrid.y, 0);

                if (ctx.gameEntity.treePosHashSet.Contains(new Vector2Int((int)pos.x, (int)pos.y))) {

                    ctx.gameEntity.handTower.SetPos(pos);
                    ctx.gameEntity.handTower.isLive = true;
                    ctx.gameEntity.handTower = null;
                } else {
                    Debug.Log("Can't build tower here" + pos);

                    foreach (Vector2Int treePos in ctx.gameEntity.treePosHashSet) {
                        Debug.Log("Tree pos: " + treePos);

                    }
                }
            }



        }
    }
}