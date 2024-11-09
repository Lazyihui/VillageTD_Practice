using System;
using UnityEngine;


namespace TD {

    public class BulletEntity : MonoBehaviour {

        public IDSignature idSig;

        public int typeID;

        public float moveSpeed;

        public float attackRange;

        public Vector3 targetPos;

        public Action<Collider2D> onTriggerEnter;

        public IDSignature targetIDSig;

        public void Ctor() {
            attackRange = 3;
            targetIDSig.entityID = -1;
        }

        public void SetPos(Vector2 pos) {
            transform.position = pos;
        }


        public void TearDown() {
            Destroy(gameObject);
        }

        void OnTriggerEnter2D(Collider2D other) {
            onTriggerEnter?.Invoke(other);

        }


    }
}