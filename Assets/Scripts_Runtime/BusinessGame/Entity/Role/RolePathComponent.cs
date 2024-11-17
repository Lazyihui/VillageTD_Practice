using System;
using UnityEngine;


namespace TD {
    public class RolePathComponent {
        public Vector2[] path;//路径点

        public int pathIndex;//当前路径点索引

        public RolePathComponent(){
            pathIndex = 0;
        }
    }

}