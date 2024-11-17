using System;
using UnityEngine;


namespace TD {
    public struct RolePathComponent {
        public Vector2[] path;//路径点

        public int pathIndex;//当前路径点索引

        public void SetPath(Vector2[] path) {
            this.path = path;
            pathIndex = 0;
        }
    }

}