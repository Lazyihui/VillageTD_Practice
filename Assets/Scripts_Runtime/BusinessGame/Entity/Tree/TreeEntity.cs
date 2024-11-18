using System;
using UnityEngine;


namespace TD {

    public class TreeEntity {

        public IDSignature idSig;
        public IDSignature idsigMap;


        public int typeID;
        public Vector2Int pos;

        // 资源
        public int resCount;

        public void Ctor() {
            resCount = 100;
        }

        public void SetPosInt(Vector2Int pos) {
            this.pos = pos;
        }


    }
}