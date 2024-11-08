using System;
using System.Collections.Generic;
using UnityEngine;



namespace TD {


    public class GameContext {
        public AppUI appUI;
        // inJect

        // 
        public GameEntity gameEntity; // 

        // Core
        public AssetsCore assetsCore;
        public InputEntity inputEntity;
        public CameraCore cameraCore;
        public TemplateCore templateCore;

        // repos
        public RoleRepository roleRepository;
        public TowerRepository towerRepository;
        public MapRepository mapRepository;
        public TreeRepository treeRepository;
        public BulletRepository bulletRepository;
        public CaveRepository caveRepository;

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
            towerRepository = new TowerRepository();
            mapRepository = new MapRepository();
            treeRepository = new TreeRepository();
            bulletRepository = new BulletRepository();
            caveRepository = new CaveRepository();
        }

        public void InJect(Canvas screenCanvas, Camera camera, Canvas worldCanvas) {
            cameraCore.Inject(camera);
            appUI.Inject(assetsCore, templateCore, screenCanvas, worldCanvas);
        }

        public bool TryGetEntityPos(IDSignature idSig, out Vector2 pos) {
            bool has;

            // Role
            has = roleRepository.TryGet(idSig, out RoleEntity entity);
            if (has) {
                pos = entity.transform.position;
                return true;
            }

            // Bullet
            has = bulletRepository.TryGet(idSig, out BulletEntity bulletEntity);
            if (has) {
                pos = bulletEntity.transform.position;
                return true;
            }

            // Tower

            pos = Vector2.zero;
            return false;
        }

        public RoleEntity Role_GetOwner() {

            bool has = roleRepository.TryGet(gameEntity.ownerIDSig, out RoleEntity entity);
            if (!has) {
                Debug.LogError("GameContext.Role_GetOwner: ownerID not found");
                return null;
            }
            return entity;
        }

        public TowerEntity Tower_GetOwner() {
            bool has = towerRepository.TryGet(0, out TowerEntity entity);
            if (!has) {
                Debug.LogError("GameContext.Tower_GetOwner: ownerID not found");
                return null;
            }
            return entity;
        }

        // public MapEntity Map_GetStage() {
        //     bool has = mapRepository.TryGet(gameEntity.stageID, out MapEntity entity);
        //     if (!has) {
        //         Debug.LogError("GameContext.Map_GetStage: stageID not found");
        //         return null;
        //     }
        //     return entity;
        // }

        public CaveEntity Cave_GetOwner(int typeID) {
            bool has = caveRepository.TryGet(typeID, out CaveEntity entity);
            if (!has) {
                Debug.LogError("GameContext.Cave_GetOwner: caveRecordID not found");
                return null;
            }
            return entity;
        }
    }
}