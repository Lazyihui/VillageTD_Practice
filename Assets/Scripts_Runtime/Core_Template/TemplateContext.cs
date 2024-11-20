using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TD.TemplateInternal {

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
        public Dictionary<int, CaveTM> caves;
        public AsyncOperationHandle cavePtr;
        public Dictionary<int, StageTM> stages;
        public AsyncOperationHandle stagePtr;
        public Dictionary<int, MapTM> maps;
        public AsyncOperationHandle mapPtr;

        public TemplateContext() {
            roles = new Dictionary<int, RoleTM>();
            towers = new Dictionary<int, TowerTM>();
            bullets = new Dictionary<int, BulletTM>();
            trees = new Dictionary<int, TreeTM>();
            panelCards = new Dictionary<int, PanelCardTM>();
            caves = new Dictionary<int, CaveTM>();
            stages = new Dictionary<int, StageTM>();
            maps = new Dictionary<int, MapTM>();
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

        public void Cave_Add(CaveTM cave) {
            caves.Add(cave.typeID, cave);
        }
        public void Stage_Add(StageTM stage) {
            stages.Add(stage.typeID, stage);
        }
    }
}