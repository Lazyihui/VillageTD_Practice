using System;
using UnityEngine;


namespace TD
{


    public class GameEntity
    {

        public float restFixTime;

        public int ownerID;

        public int towerRecordID;

        public GameState state;
        public GameEntity()
        {
            restFixTime = 0;
            ownerID = 0;
            towerRecordID = 0;
            state = GameState.Login;
        }
    }
}