using System;
using UnityEngine;

namespace TD {

    [CreateAssetMenu(fileName = "RoleSO", menuName = "TD/RoleSO")]
    public class RoleSO : ScriptableObject {
        public RoleTM tm;
    }

    [Serializable]
    public class RoleTM {

        public int typeID;

        public RoleTM() { }

    }

}