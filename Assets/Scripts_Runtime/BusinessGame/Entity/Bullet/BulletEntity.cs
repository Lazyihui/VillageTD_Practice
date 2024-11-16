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

        // 记录目标mst
        public IDSignature targetIDSig;
        // 记录目标方向
        public Vector3 targetDir;

        public void Ctor() {
            attackRange = 3;
            targetIDSig.entityID = -1;
        }

        public void SetPos(Vector2 pos) {
            transform.position = pos;
        }

        public void Move(Vector2 dir, float dt) {
            Vector3 pos = transform.position;
            Vector3 newDir = new Vector3(dir.x, dir.y, 0);
            pos += newDir * moveSpeed * dt;
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