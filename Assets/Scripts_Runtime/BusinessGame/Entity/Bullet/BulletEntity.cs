using System;
using UnityEngine;


namespace TD {

    public class BulletEntity : MonoBehaviour {
        public int id;

        public int typeID;

        public float moveSpeed;

        public float attackRange;

        public Vector3 targetPos;

        public Action<Collider2D> onTriggerEnter;

        public void Ctor() {
            attackRange = 3;
        }

        public void SetPos(Vector2 pos) {
            transform.position = pos;
        }


        public void TearDown() {
            Destroy(gameObject);
        }

        void OnTriggerEnter2D(Collider2D other) {
            onTriggerEnter?.Invoke(other);
            if (other.tag == "Mst") {
                Debug.Log("BulletEntity OnTriggerEnter2D");
            }else{
                Debug.Log("ggggg");

            }
            Debug.Log(",,,,,");
        }
    }
}