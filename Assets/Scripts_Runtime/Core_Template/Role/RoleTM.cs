using System;
using UnityEngine;

namespace TD {



    [Serializable]
    public class RoleTM {
        public string typeName;

        public string tag;
        public int typeID;

        public float moveSpeed;

        public float rbMass;
    
        [Header("Role")]
        public float attackSpeed;

        public float attackRange;

        public GameObject modPrefab;

        public Sprite sp;

    



    }

}