using System;
using System.Collections.Generic;
using UnityEngine;



namespace TD {


    public class GameContext {

        public GameEntity gameEntity;

        // Core
        public AssetsCore assetsCore;


        public GameContext() {
            gameEntity = new GameEntity();
            assetsCore = new AssetsCore();
        }
    }
}