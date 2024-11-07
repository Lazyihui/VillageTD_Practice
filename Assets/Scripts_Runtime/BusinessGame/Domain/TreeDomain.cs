using System;
using UnityEngine;


namespace TD {

    public static class TreeDomain {

        public static TreeEntity Spawn(GameContext ctx, Vector2Int pos, int typeID) {

            TreeEntity entity = GameFactory.Tree_Create(ctx, pos, typeID);

            ctx.treeRepository.Add(entity);
            ctx.treeRepository.AddPos(pos, entity);
            return null;
        }
    }
}