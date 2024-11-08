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
    }
}