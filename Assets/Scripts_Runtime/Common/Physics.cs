using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {

    public static class Physics {

        public static TreeEntity FindNearestTree(GameContext ctx, TowerEntity tower) {

            int len = ctx.treeRepository.TakeAll(out TreeEntity[] trees);

            float minDistance = float.MaxValue;
            TreeEntity nearestTree = null;

            for (int i = 0; i < len; i++) {
                TreeEntity tree = trees[i];
                float distance = Vector2.Distance(tree.pos, tower.transform.position);
                if (distance < minDistance && distance < tower.attackRange) {
                    minDistance = distance;
                    nearestTree = tree;
                }
            }

            return nearestTree;

        }

    }

}