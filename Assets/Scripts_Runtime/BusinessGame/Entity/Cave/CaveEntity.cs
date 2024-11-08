using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {

    public class CaveEntity : MonoBehaviour {

        public IDSignature idSig;
        public int typeID;
        public float caveSpawnTime;
        public float caveSpawnInterval;

        public bool isLive;

        public void Ctor() {
            isLive = false;
        }


        public void SetPos(Vector3 pos) {
            transform.position = pos;
        }

    }
}