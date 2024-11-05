using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {


    public class RoleEntity : MonoBehaviour {

        [SerializeField] Rigidbody2D rb;
        [SerializeField] SpriteRenderer sp;
        [SerializeField] GameObject circle;

        public int id;

        public int typeID;
        public float moveSpeed;

        public float attackHurt;

        public float attackRange;


        public RoleInputComponent inputCom;

        public void Ctor() {
            attackRange = 3;
            attackHurt = 1;

        }

        public void SetRbMass(float mass) {
            rb.mass = mass;
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

        public void SetSprite(Sprite sp) {
            this.sp.sprite = sp;
        }

        public void SetCircleActive() {
            if (typeID == RoleConst.Role) {
                circle.SetActive(true);
            } else {
                circle.SetActive(false);
            }
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