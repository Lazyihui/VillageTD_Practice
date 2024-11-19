using System;
using UnityEngine;
using UnityEditor;


namespace TD {


    public class StageEM : MonoBehaviour {
        public int typeID;

        public StageSO so;

        [SerializeField] GameObject modelMap;

        // 第一件事将数据保存到TM里
        [ContextMenu("Save")]
        public void Save() {

            string n = "stage_" + typeID;
            if (gameObject.name != n) {
                gameObject.name = n;
            }
            so.tm.typeID = typeID;

            so.tm.mapEntity = modelMap;

            Debug.Log("Save");
            SaveRole();
            SaveCave();
            SaveMap();
            SaveTower();
        }



        public void SaveRole() {
            RoleSpawnerEM[] rolesEM = GetComponentsInChildren<RoleSpawnerEM>();
            Debug.Log(rolesEM.Length);
            RoleSpawnTM[] rolesTM = new RoleSpawnTM[rolesEM.Length];

            for (int i = 0; i < rolesTM.Length; i++) {
                RoleSpawnerEM em = rolesEM[i];

                em.Save();
                rolesTM[i] = em.spawnTM;
            }

            so.tm.roleSpawnTMs = rolesTM;
            EditorUtility.SetDirty(so);
        }

        public void SaveCave() {
            CaveSpawnEM[] cavesEM = GetComponentsInChildren<CaveSpawnEM>();
            Debug.Log(cavesEM.Length);
            CaveSpawnTM[] cavesTM = new CaveSpawnTM[cavesEM.Length];

            for (int i = 0; i < cavesTM.Length; i++) {
                CaveSpawnEM em = cavesEM[i];
                em.Save();
                cavesTM[i] = em.caveSpawnTM;
            }
            so.tm.caveSpawnTMs = cavesTM;
            EditorUtility.SetDirty(so);
        }

        public void SaveTower() {
            TowerSpawnEM[] towersEM = GetComponentsInChildren<TowerSpawnEM>();
            Debug.Log(towersEM.Length);
            TowerSpawnTM[] towerTM = new TowerSpawnTM[towersEM.Length];

            for (int i = 0; i < towerTM.Length; i++) {
                TowerSpawnEM em = towersEM[i];
                em.Save();
                towerTM[i] = em.towerSpawnTM;
            }
            so.tm.towerSpawnTMs = towerTM;
            EditorUtility.SetDirty(so);

        }

        public void SaveMap() {
            so.tm.mapEntity = modelMap;
            EditorUtility.SetDirty(so);
        }


    }
}