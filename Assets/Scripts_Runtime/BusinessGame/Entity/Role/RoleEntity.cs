using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {


    public class RoleEntity : MonoBehaviour {

        [SerializeField] Rigidbody2D rb;

        public int id;

        public int typeID;
        public float moveSpeed;


        public RoleInputComponent inputCom;

        public void Ctor() {
            moveSpeed = 5.5f;
        }

        public void SetPos(Vector3 pos) {
            transform.position = pos;
        }

        public void Move(float dt) {

            inputCom.moveAxis = inputCom.moveAxis.normalized * this.moveSpeed;
            rb.velocity = inputCom.moveAxis;
        }

        public void Set_MoveAxis(Vector2 moveAxis) {
            inputCom.moveAxis = moveAxis;
        }



        public void TF_SetPostion(Vector3 pos) {
            transform.position = pos;
        }

        public void TF_SetRotation(Vector3 rot) {
            transform.rotation = Quaternion.Euler(rot);
        }
        public void TearDown() {
            Destroy(gameObject);
        }
    }
}