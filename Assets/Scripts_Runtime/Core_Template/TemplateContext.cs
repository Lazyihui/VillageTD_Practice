using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TD {

    public class TemplateContext {


        GameTM game;
        public Dictionary<int, RoleTM> roles;

        public AsyncOperationHandle rolePtr;

        public Dictionary<int, TowerTM> towers;

        public AsyncOperationHandle towerPtr;

        public Dictionary<int, BulletTM> bullets;

        public AsyncOperationHandle bulletPtr;

        public Dictionary<int, TreeTM> trees;

        public AsyncOperationHandle treePtr;

        public Dictionary<int, PanelCardTM> panelCards;

        public AsyncOperationHandle panelCardPtr;

        public TemplateContext() {
            roles = new Dictionary<int, RoleTM>();
            towers = new Dictionary<int, TowerTM>();
            bullets = new Dictionary<int, BulletTM>();
            trees = new Dictionary<int, TreeTM>();
            panelCards = new Dictionary<int, PanelCardTM>();
        }

        // 找种类的Role
        public bool Role_TryGet(int typeID, out RoleTM role) {
            return roles.TryGetValue(typeID, out role);
        }

        public bool Tower_TryGet(int typeID, out TowerTM tower) {
            return towers.TryGetValue(typeID, out tower);
        }

        public bool Bullet_TryGet(int typeID, out BulletTM bullet) {
            return bullets.TryGetValue(typeID, out bullet);
        }

        public bool Tree_TryGet(int typeID, out TreeTM tree) {
            return trees.TryGetValue(typeID, out tree);
        }

        public bool PanelCard_TryGet(int typeID, out PanelCardTM panelCard) {
            return panelCards.TryGetValue(typeID, out panelCard);
        }

        public void Game_Set(GameTM game) {
            this.game = game;
        }

        public void Role_Add(RoleTM role) {
            roles.Add(role.typeID, role);
        }

        public void Tower_Add(TowerTM tower) {
            towers.Add(tower.typeID, tower);
        }

        public void Bullet_Add(BulletTM bullet) {
            bullets.Add(bullet.typeID, bullet);
        }

        public void Tree_Add(TreeTM tree) {
            trees.Add(tree.typeID, tree);
        }
        public void PanelCard_Add(PanelCardTM panelCard) {
            panelCards.Add(panelCard.typeID, panelCard);
        }
    }
}