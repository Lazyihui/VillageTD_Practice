using System;
using System.Collections;
using UnityEngine;
using UnityEditor;

namespace TD {
    [ExecuteInEditMode]
    public class TowerSpawnEM : MonoBehaviour {

        public TowerSpawnTM towerSpawnTM;

        void Update() {

            var so = towerSpawnTM.so;
            if (so == null) {
                return;
            }

            var tm = so.tm;

            string n = "Tower_Entity" + tm.typeID;
            if (gameObject.name != n) {
                gameObject.name = n;
            }

        }


        [ContextMenu("Save")]

        public void Save() {
            Debug.Log("Save_Tower");
            towerSpawnTM.position = transform.position;
            towerSpawnTM.rotation = transform.rotation.eulerAngles;
        }

    }
}


