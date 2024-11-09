using System;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public static class CaveDomain {
        public static CaveEntity Spawn(GameContext ctx, int typeID, Vector3 pos) {

            CaveEntity cave = GameFactory.Cave_Create(ctx, typeID, pos);
            ctx.caveRepository.Add(cave);
            return cave;

        }

        public static void UnSpawn(GameContext ctx, CaveEntity cave) {
            ctx.caveRepository.Remove(cave);
            cave.TearDown();
        }

        public static void ActiveCave(GameContext ctx, CaveEntity cave, float dt) {
            if (cave.isLive == true) {
                return;
            }

            cave.activeTimer += dt;
            if (cave.activeTimer >= cave.activeInterval) {
                cave.isLive = true;
            }

        }

        public static void CaveSpawnMst(GameContext ctx, CaveEntity cave,float dt) {
            if(cave.spawnCount >= cave.spawnMaxCount) {
                return;
            }

            cave.caveSpawnTime += dt;
            if (cave.caveSpawnTime >= cave.caveSpawnInterval) {
                cave.caveSpawnTime = 0;
                cave.spawnCount++;
                Vector3 pos = cave.transform.position;
                RoleDomain.Spawn(ctx, RoleConst.Monster, pos);
            }

        }
    }
}