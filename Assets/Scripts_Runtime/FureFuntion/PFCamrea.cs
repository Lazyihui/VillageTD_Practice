using System;
using System.Collections.Generic;
using UnityEngine;


public static class PFCamera{

    public static Vector3 Follow(Vector3 camPos,Vector2 target){
        return new Vector3(target.x, target.y, camPos.z);
    }
}