using System;
using UnityEngine;

namespace TD {

    [Serializable]
    public class TowerTM {

        public int typeID;

        public int hp;

        public int maxHp;

        public float shootTimer;

        public float shootInterval;
        public float attackHurt;

        public float attackRange;

        public Sprite sprite;

        public bool isLive;


    }
}