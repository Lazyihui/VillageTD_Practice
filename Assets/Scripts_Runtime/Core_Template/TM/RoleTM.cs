using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {

    [CreateAssetMenu(fileName = "RoleSO", menuName = "TD/RoleSO")]
    public class RoleSO : ScriptableObject {
        public RoleTM tm;
    }

    // 啥意思
    [Serializable]
    public class RoleTM {

        public int typeID;

        public RoleTM() { }
    }
}

