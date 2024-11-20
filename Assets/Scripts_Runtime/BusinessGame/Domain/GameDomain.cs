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

            // 游戏胜利
            FlagHp_GameWin(ctx);
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
        #region Victory
        public static void FlagHp_GameWin(GameContext ctx) {
            GameEntity game = ctx.gameEntity;

            if (game.isCavrSpawnMstOver) {

                int mstCount = 0;

                int len = ctx.roleRepository.TakeAll(out RoleEntity[] roles);
                for (int i = 0; i < len; i++) {
                    RoleEntity role = roles[i];

                    if (role.fsmCom.isRole) {
                        continue;
                    }
                    if (role.fsmCom.isOrdinaryMst) {
                        mstCount++;
                    }
                }

                // 胜利
                if (mstCount == 0) {
                    IDSignature idSig = new IDSignature(EntityType.Tower, 0);
                    bool has = ctx.towerRepository.TryGet(idSig, out TowerEntity entity);
                    if (entity.hp > 0) {
                        ClearAll(ctx);
                        ctx.appUI.Panel_Victory_Open();
                    }

                }

            }

        }
        #endregion
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