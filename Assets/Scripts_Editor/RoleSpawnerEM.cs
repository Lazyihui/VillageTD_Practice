using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TD {


    [ExecuteInEditMode]
    public class RoleSpawnerEM : MonoBehaviour {

        public RoleSpawnTM spawnTM;



        void Update() {

            var so = spawnTM.so;
            if (so == null) {
                return;
            }

            var tm = so.tm;
            // var prefab = tm.modPrefab;
            // if (prefab == null) {
            //     return;
            // }

            // if (transform.childCount == 0) {
            //     var mod = GameObject.Instantiate(prefab, transform);
            //     Debug.Log(mod.name);
            // }

            string n = "player_" + tm.typeName;
            if (gameObject.name != n) {
                gameObject.name = n;
            }

        }

        [ContextMenu("Save")]

        public void Save() {
            Debug.Log("Save");

            spawnTM.position = transform.position;
            spawnTM.rotation = transform.rotation.eulerAngles;
        }
    }
}