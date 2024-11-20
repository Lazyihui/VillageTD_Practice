using System;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public static class CaveDomain {
        public static CaveEntity Spawn(GameContext ctx, int typeID, CaveSpawnTM spawnTM) {

            CaveEntity cave = GameFactory.Cave_Create(ctx, typeID, spawnTM);
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

            if (cave.activeTimer > cave.activeInterval) {
                return;
            }

            cave.activeTimer += dt;
            if (cave.activeTimer >= cave.activeInterval) {
                cave.isLive = true;
            }

        }

        public static bool CaveSpawnMst(GameContext ctx, CaveEntity cave, float dt) {

            if (cave.spawnCount >= cave.spawnMaxCount) {
                return true;
            }

            cave.caveSpawnTime += dt;
            if (cave.caveSpawnTime >= cave.caveSpawnInterval) {
                cave.spawnCount+=1;
                Vector3 pos = cave.transform.position;
                RoleDomain.SpawnMst(ctx, RoleConst.Monster, pos, cave.mstMovePath);
                cave.caveSpawnTime = 0;
            }

            return false;
        }

        public static void Clear(GameContext ctx) {
            int len = ctx.caveRepository.TakeAll(out CaveEntity[] caves);
            for (int i = 0; i < len; i++) {
                CaveEntity cave = caves[i];
                UnSpawn(ctx, cave);
            }
        }

    }
}