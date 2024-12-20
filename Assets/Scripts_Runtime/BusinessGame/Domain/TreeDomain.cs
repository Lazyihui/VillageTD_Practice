using System;
using UnityEngine;


namespace TD {

    public static class TreeDomain {

        public static TreeEntity Spawn(GameContext ctx, Vector2Int pos, int typeID, IDSignature idsigMap) {

            TreeEntity entity = GameFactory.Tree_Create(ctx, pos, typeID, idsigMap);

            ctx.treeRepository.Add(entity);
            ctx.treeRepository.AddPos(pos, entity);

            // 画树 
            MapEntity mapEntity = ctx.mapRepository.GetMapByMousePos(pos);
            MapDomain.SetTile(ctx, mapEntity.treeGrid.tilemap, 1, pos);
            return null;
        }

        public static void UnSpawn(GameContext ctx, TreeEntity entity) {
            ctx.treeRepository.Remove(entity);
            ctx.treeRepository.RemovePos(entity.pos);

        }

        public static void Clear(GameContext ctx) {
            int len = ctx.treeRepository.TakeAll(out TreeEntity[] trees);
            for (int i = 0; i < len; i++) {
                TreeEntity tree = trees[i];
                UnSpawn(ctx, tree);
            }
        }


    }
}