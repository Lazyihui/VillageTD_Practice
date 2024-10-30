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
    }
}