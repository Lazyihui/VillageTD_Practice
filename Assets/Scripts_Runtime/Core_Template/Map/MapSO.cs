using System;
using System.Collections;
using UnityEngine;



namespace TD {
    [CreateAssetMenu(fileName = "So_Map", menuName = "TD/So_Map")]
    public class MapSO : ScriptableObject {
        public MapTM tm;
    }
}