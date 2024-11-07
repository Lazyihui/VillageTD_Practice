using System;
using UnityEngine;


namespace TD {


    public static class GameDomain {
        public static void SetTowerPos(GameContext ctx) {
            if (ctx.gameEntity.handTower == null) {
                return;
            }

            ctx.gameEntity.handTower.SetPos(ctx.inputEntity.mousePositionGrid);
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