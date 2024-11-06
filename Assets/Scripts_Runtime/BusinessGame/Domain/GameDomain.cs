using System;
using UnityEngine;


namespace TD {


    public static class GameDomain {
        public static void SetTowerPos(GameContext ctx) {
            if (ctx.gameEntity.handTower == null) {
                return;
            }

            Vector3 pos = new Vector3(ctx.inputEntity.mousePositionGrid.x, ctx.inputEntity.mousePositionGrid.y, 0);
            ctx.gameEntity.handTower.transform.position = pos;


        }
    }
}