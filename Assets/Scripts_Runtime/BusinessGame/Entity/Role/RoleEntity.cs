using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {


    public class RoleEntity : MonoBehaviour {

        [SerializeField] Rigidbody2D rb;

        public int id;


        public RoleInputComponent inputCom;

        public void Ctor() {

        }

        public void SetPos(Vector3 pos) {
            transform.position = pos;
        }

        public void Move(float dt,Vector2 moveAxis,float moveSpeed) {
            moveAxis = moveAxis.normalized * moveSpeed;
            rb.velocity = moveAxis;
        }

        public void Set_MoveAxis(Vector2 moveAxis) {
            inputCom.moveAxis = moveAxis;
        }

        public void TearDown() {
            Destroy(gameObject);
        }
    }
}