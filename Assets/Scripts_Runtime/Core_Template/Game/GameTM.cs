using System;
using UnityEngine;


namespace TD {

    // 啥意思
    [Serializable]
    public class GameTM {

        // 基地的位置
        public Vector2 baseHouse;

        public int baseHouseHp;

        // 角色的生成位置
        public Vector2 roleSpawnPos;

        public MapEntity mapModel;


        public GameTM() { }
    }
}

