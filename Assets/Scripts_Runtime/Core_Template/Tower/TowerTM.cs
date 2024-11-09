using System;
using UnityEngine;

namespace TD {

    [Serializable]
    public class TowerTM {

        public string typeName;
        public PlaceConditionType placeConditionType;
        public int typeID;
        public int hp;
        public int maxHp;
        public int buildCost;


        public float shootTimer;
        public float shootInterval;
        public float attackHurt;

        public float attackRange;

        public Sprite sprite;

        public bool isLive;

        [Header("砍树时间")]
        public float cutTreeTime;

        public float cutTreeInterval;
        public int cutHurt;

        [Header("bool")]
        public TowerFSMComponent fsmCom;

        public bool isTrigger;



    }
}