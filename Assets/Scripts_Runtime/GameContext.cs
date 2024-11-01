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

        public CameraCore cameraCore;

        public TemplateCore templateCore;
        public AppUI appUI;

        // repos
        public RoleRepository roleRepository;


        public GameContext() {

            gameEntity = new GameEntity();

            // Core
            assetsCore = new AssetsCore();
            cameraCore = new CameraCore();
            inputEntity = new InputEntity();
            templateCore = new TemplateCore();
            appUI = new AppUI();

            // Repos
            roleRepository = new RoleRepository();

        }

        public void InJect(Canvas screenCanvas,Camera camera) {
            this.screenCanvas = screenCanvas;
            cameraCore.Inject(camera);
        }

        public RoleEntity Role_GetOwner() {

            bool has = roleRepository.TryGet(gameEntity.ownerID, out RoleEntity entity);
            if (!has) {
                Debug.LogError("GameContext.Role_GetOwner: ownerID not found");
                return null;
            }
            return entity;
        }
       
    }
}