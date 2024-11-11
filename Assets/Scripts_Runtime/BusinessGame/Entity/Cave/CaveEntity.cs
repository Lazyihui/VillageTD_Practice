using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {

    public class CaveEntity : MonoBehaviour {

        public IDSignature idSig;
        public int typeID;

        // hp之后加


        public float caveSpawnTime;
        public float caveSpawnInterval;


        // 激活条件
        public bool isLive;
        public float activeTimer;
        public float activeInterval;

        // 生成数量
        public int spawnCount;
        public int spawnMaxCount;

        public void Ctor() {
            spawnCount = 0;
        }


        public void SetPos(Vector3 pos) {
            transform.position = pos;
        }

        public void TearDown() {
            Destroy(gameObject);
        }


        public void TF_SetPostion(Vector3 pos) {
            transform.position = pos;
        }

        public void TF_SetRotation(Vector3 rot) {
            transform.rotation = Quaternion.Euler(rot);
        }

    }
}