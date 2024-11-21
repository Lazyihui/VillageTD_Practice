using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

namespace TD {


    public class AssetsCore {
        public Dictionary<string, GameObject> entities;


        public AsyncOperationHandle entitiesHandle;

        public Dictionary<string, GameObject> panels;

        public AsyncOperationHandle panelsHandle;

        public AssetsCore() {
            entities = new Dictionary<string, GameObject>();
            panels = new Dictionary<string, GameObject>();
        }


        public async Task LoadAll() {
            {
                AssetLabelReference labelReference = new AssetLabelReference();

                labelReference.labelString = "Entity";
                var handle = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);

                var all = await handle.Task;
                foreach (var item in all) {
                    entities.Add(item.name, item);
                }

                entitiesHandle = handle;
            }

            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "Panel";
                var handle = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);

                var all = await handle.Task;

                foreach (var item in all) {
                    panels.Add(item.name, item);
                }

                panelsHandle = handle;
            }
        }


        public void UnLoadAll() {
            if (entitiesHandle.IsValid()) {
                Addressables.Release(entitiesHandle);
            }
            if (panelsHandle.IsValid()) {
                Addressables.Release(panelsHandle);
            }
        }
        // Entity
        public GameObject Entity_GetRole() {
            entities.TryGetValue("Entity_Role", out GameObject role);
            return role;
        }

        public GameObject Entity_GetTower() {
            entities.TryGetValue("Entity_Tower", out GameObject tower);
            return tower;
        }

        public GameObject Entity_GetBullet() {
            entities.TryGetValue("Entity_Bullet", out GameObject bullet);
            return bullet;
        }

        public GameObject Entity_GetCave() {
            entities.TryGetValue("Entity_Cave", out GameObject cave);
            return cave;
        }

        //  panel 

        public GameObject Panel_GetLogin() {
            panels.TryGetValue("Panel_Login", out GameObject panel);
            return panel;
        }

        public GameObject Panel_GetManifast() {
            panels.TryGetValue("Panel_Manifast", out GameObject panel);
            return panel;
        }

        public GameObject Panel_GetManifastElement() {
            panels.TryGetValue("Panel_ManifastElement", out GameObject panel);
            return panel;
        }


        public GameObject Panel_GetResourceInfo() {
            panels.TryGetValue("Panel_ResourceInfo", out GameObject panel);
            return panel;
        }

        public GameObject Panel_GetSelectCard() {
            panels.TryGetValue("Panel_SelectCard", out GameObject panel);
            return panel;
        }

        public GameObject Panel_GetTowerInfo() {
            panels.TryGetValue("Panel_TowerInfo", out GameObject panel);
            return panel;
        }

        public GameObject Panel_Victory() {
            panels.TryGetValue("Panel_Victory", out GameObject panel);
            return panel;
        }

        public GameObject Panel_GetFail() {
            panels.TryGetValue("Panel_Fail", out GameObject panel);
            return panel;
        }

        public GameObject Panel_GetGuide() {
            panels.TryGetValue("Panel_Guide", out GameObject panel);
            return panel;
        }

        public GameObject Panel_GetGuidePanel() {
            panels.TryGetValue("Panel_ManifastInfo", out GameObject panel);
            return panel;
        }

        public GameObject Panel_GetNotice() {
            panels.TryGetValue("Panel_Notice", out GameObject panel);
            return panel;
        }

        public GameObject Panel_GetStageSelection() {
            panels.TryGetValue("Panel_StageSelection", out GameObject panel);
            return panel;
        }

        public GameObject Panel_GetStageSelectionElement() {
            panels.TryGetValue("Panel_StageSelectionElement", out GameObject panel);
            return panel;
        }
        // HUD
        public GameObject HUD_GetGatherHint() {
            panels.TryGetValue("HUD_GatherHint", out GameObject hud);
            return hud;
        }

        public GameObject HUD_GetInteractPopup() {
            panels.TryGetValue("HUD_InteractPopup", out GameObject hud);
            return hud;
        }
        // map

        public GameObject Entity_GetMap() {
            entities.TryGetValue("Entity_Map", out GameObject map);
            return map;
        }

        public GameObject Entity_GetTileGround() {
            entities.TryGetValue("Grid_Stage1_Ground", out GameObject mapTile);
            return mapTile;
        }

        public GameObject Entity_GetTileTree() {
            entities.TryGetValue("Grid_Stage1_Tree", out GameObject mapTile);
            return mapTile;
        }


    }
}