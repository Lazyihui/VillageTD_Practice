using System;
using UnityEngine;


namespace TD {


    public static class GameDomain {

        public static void Tick(GameContext ctx, float dt) {

            // 塔card的位置和鼠标格子位置一样
            SetPanelCardPos(ctx);
            // 右键取消card
            CancelBuiidTowerCard(ctx);

            // 游戏结束
            FlagHp_GameFail(ctx);
        }


        public static void SetPanelCardPos(GameContext ctx) {
            if (ctx.gameEntity.handHasCard || ctx.gameEntity.handHasCardTree) {

                Vector2Int pos = ctx.inputEntity.mousePositionGrid;
                ctx.appUI.Panel_SelectCard_SetPos(pos);
            }
        }

        public static void CancelBuiidTowerCard(GameContext ctx) {
            if (ctx.gameEntity.handHasCard || ctx.gameEntity.handHasCardTree) {

                if (ctx.inputEntity.mouseRightClick) {
                    ctx.appUI.Panel_SelectCard_Close();
                    ctx.gameEntity.handHasCard = false;
                }
            }
        }

        public static void FlagHp_GameFail(GameContext ctx) {
            TowerEntity owner = ctx.Tower_GetOwner();
            if (owner == null) {
                return;
            }

            if (owner.hp <= 0) {
                ctx.gameEntity.state = GameState.GameOver;
                ctx.appUI.Panel_Fail_Open();

                ClearAll(ctx);
            }
        }

        #region  clear

        public static void ClearAll(GameContext ctx) {
            // 关闭Entity
            BulletDomain.Clear(ctx);
            CaveDomain.Clear(ctx);
            MapDomain.Clear(ctx);
            RoleDomain.Clear(ctx);
            TowerDomain.Clear(ctx);
            TreeDomain.Clear(ctx);

            // 关闭UI
            ctx.appUI.Clear();
            // 重置游戏
            ctx.gameEntity.Ctor();
        }

        #endregion

    }
}