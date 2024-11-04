using System;
using UnityEngine;


namespace TD {

    public class TreeEntity {

        public int id;

        public int typeID;
        public Vector2Int pos;

        public void Ctor() {

        }

        public void SetPosInt(Vector2Int pos) {
            this.pos = pos;
        }

    }
}