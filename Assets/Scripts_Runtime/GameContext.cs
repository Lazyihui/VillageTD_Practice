using System;
using System.Collections.Generic;
using UnityEngine;



namespace TD {


    public class GameContext {

        // inJect

        public Canvas screenCanvas;

        // 

        public GameEntity gameEntity;

        // Core
        public AssetsCore assetsCore;

        public InputEntity inputEntity;

        public AppUI appUI;

        // repos
        public RoleRepository roleRepository;


        public GameContext() {

            gameEntity = new GameEntity();

            // Core
            assetsCore = new AssetsCore();
            inputEntity = new InputEntity();
            appUI = new AppUI();

            // Repos
            roleRepository = new RoleRepository();

        }

        public void InJect(Canvas screenCanvas) {
            this.screenCanvas = screenCanvas;
        }

        public RoleEntity Role_GetOwner() {

            bool has = roleRepository.TryGet(gameEntity.ownerID, out RoleEntity entity);
            if (!has) {
                Debug.LogError("GameContext.Role_GetOwner: ownerID not found");
                return null;
            }
            return entity;
        }
        // public RoleEntity Role_GetOwner() {
        //     bool has = roleRepo.TryGet(gameEntity.roleOwnerID, out RoleEntity entity);
        //     if (!has) {
        //         Debug.LogError("GameContext.Role_GetOwner: roleOwnerID not found");
        //         return null;
        //     }
        //     return entity;
        // }
    }
}