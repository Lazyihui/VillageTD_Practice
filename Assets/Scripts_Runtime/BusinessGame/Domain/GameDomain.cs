using System;
using UnityEngine;


namespace TD {


    public static class GameDomain {

        public static void Tick(GameContext ctx, float dt) {

            // 塔card的位置和鼠标格子位置一样
            SetPanelCardPos(ctx);
            // 右键取消card
            CancelBuiidTowerCard(ctx);
        }


        public static void SetPanelCardPos(GameContext ctx) {
            if (!ctx.gameEntity.isHandHasCard) {
                return;
            }
            Vector2Int pos = ctx.inputEntity.mousePositionGrid;
            ctx.appUI.Panel_SelectCard_SetPos(ctx, pos);
        }

        public static void CancelBuiidTowerCard(GameContext ctx) {
            if (!ctx.gameEntity.isHandHasCard) {
                return;
            }

            if (ctx.inputEntity.mouseRightClick) {
                ctx.appUI.Panel_SelectCard_Close(ctx);
                ctx.gameEntity.isHandHasCard = false;
            }
        }

    }
}