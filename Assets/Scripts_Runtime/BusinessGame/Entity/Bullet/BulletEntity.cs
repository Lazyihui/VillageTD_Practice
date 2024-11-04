using System;
using UnityEngine;


namespace TD{

    public class BulletEntity : MonoBehaviour{
         public int id;

        public int typeID;

        public float moveSpeed;

        public void Ctor() {

        }

        public void SetPos(Vector2 pos) {
            transform.position = pos;
        }


        public void TearDown() {
            Destroy(gameObject);
        }
    }
}