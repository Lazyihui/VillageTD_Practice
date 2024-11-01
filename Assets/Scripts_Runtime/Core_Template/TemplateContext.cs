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
        public TemplateContext() {
            roles = new Dictionary<int, RoleTM>();
        }

        // 找种类的Role
        public bool Role_TryGet(int typeID, out RoleTM role) {
            return roles.TryGetValue(typeID, out role);
        }

        public void Game_Set(GameTM game) {
            this.game = game;
        }

        // public bool Role_TryGet() {

        // }
    }
}