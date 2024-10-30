using System;
using System.Collections.Generic;
using UnityEngine;



namespace TD {


    public class GameContext {

        public GameEntity gameEntity;

        // Core
        public AssetsCore assetsCore;

        // repos
        public RoleRepository roleRepository;


        public GameContext() {

            gameEntity = new GameEntity();

            // Core
            assetsCore = new AssetsCore();

            // Repos
            roleRepository = new RoleRepository();

        }
    }
}