using System;
using UnityEngine;
using UnityEditor;


namespace TD {


    public class StageEM : MonoBehaviour {
        public int typeID;

        public StageSO so;


        // 第一件事将数据保存到TM里
        [ContextMenu("Save")]
        public void Save() {

            string n = "stage_" + typeID;
            if (gameObject.name != n) {
                gameObject.name = n;
            }
            so.tm.typeID = typeID;

            Debug.Log("Save");
            SaveRole();
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
    }
}