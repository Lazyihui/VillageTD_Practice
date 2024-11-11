using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD {

    [CreateAssetMenu(fileName = "GameSO", menuName = "GameSO")]

    public class GameSO : ScriptableObject {
        public GameTM tm;
    }
}