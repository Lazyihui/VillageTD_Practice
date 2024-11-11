using System;
using System.Collections;
using UnityEngine;


namespace TD {

    [ExecuteInEditMode]
    public class CaveSpawnEM : MonoBehaviour {

        public CaveSpawnTM caveSpawnTM;


        void Update() {

            var so = caveSpawnTM.so;
            if (so == null) {
                return;
            }

            var tm = so.tm;

            string n = "Cave_Entity" + tm.typeName;
            if (gameObject.name != n) {
                gameObject.name = n;
            }

        }

        [ContextMenu("Save")]
        public void Save() {
            Debug.Log("Cave_Save");
            caveSpawnTM.position = transform.position;
            caveSpawnTM.rotation = transform.rotation.eulerAngles;
        }

    }
}