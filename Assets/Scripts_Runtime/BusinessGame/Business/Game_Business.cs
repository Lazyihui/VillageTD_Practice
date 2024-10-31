using System;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public static class Game_Business {

        public static void Enter(GameContext ctx) {

            RoleEntity owner = RoleDomain.Spawn(ctx);
            ctx.gameEntity.ownerID = owner.id;

        }


        public static void Tick(GameContext ctx, float dt) {
            PreTick(ctx, dt);

            ref float restFixTime = ref ctx.gameEntity.restFixTime;

            restFixTime += dt;

            restFixTime += dt;
            const float FIX_INTERVAL = 0.020f;

            if (restFixTime <= FIX_INTERVAL) {

                LogicTick(ctx, restFixTime);

                restFixTime = 0;
            } else {
                while (restFixTime >= FIX_INTERVAL) {
                    LogicTick(ctx, FIX_INTERVAL);
                    restFixTime -= FIX_INTERVAL;
                }
            }

            LastTick(ctx, dt);
        }


        static void PreTick(GameContext ctx, float dt) {

            RoleEntity owner = ctx.Role_GetOwner();

            RoleDomain.Set_MoveAxis(owner, ctx.inputEntity.moveAxis);


        }

        static void LogicTick(GameContext ctx, float dt) {
            RoleEntity owner = ctx.Role_GetOwner();

            RoleDomain.Move(owner, dt);
        }

        static void LastTick(GameContext ctx, float dt) {
            RoleEntity owner = ctx.Role_GetOwner();
            
            ctx.cameraCore.Follow(owner.transform.position);
            Debug.Log("Game_Business.LastTick: " + owner.transform.position);
        }
    }
}