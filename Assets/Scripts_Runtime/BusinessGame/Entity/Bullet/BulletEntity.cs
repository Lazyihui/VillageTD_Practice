using System;
using UnityEngine;


namespace TD {

    public class BulletEntity : MonoBehaviour {
        public int id;

        public int typeID;

        public float moveSpeed;

        public float attackRange;

        public Vector3 targetPos;

        public void Ctor() {
            attackRange = 3;
        }

        public void SetPos(Vector2 pos) {
            transform.position = pos;
        }


        public void TearDown() {
            Destroy(gameObject);
        }

        
    }
}