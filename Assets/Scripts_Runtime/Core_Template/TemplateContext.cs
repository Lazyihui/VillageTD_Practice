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

        public Dictionary<int,TowerTM> towers;

        public AsyncOperationHandle towerPtr;
        public TemplateContext() {
            roles = new Dictionary<int, RoleTM>();
            towers = new Dictionary<int, TowerTM>();
        }

        // 找种类的Role
        public bool Role_TryGet(int typeID, out RoleTM role) {
            return roles.TryGetValue(typeID, out role);
        }

        public bool Tower_TryGet(int typeID, out TowerTM tower) {
            return towers.TryGetValue(typeID, out tower);
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


    }
}