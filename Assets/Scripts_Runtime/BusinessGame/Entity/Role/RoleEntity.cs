using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD {


    public class RoleEntity : MonoBehaviour {

        [SerializeField] Rigidbody2D rb;
        [SerializeField] SpriteRenderer sp;
        [SerializeField] GameObject circle;

        [SerializeField] GameObject go;

        public IDSignature idSig;
        public int id;

        public int typeID;
        public float moveSpeed;

        public int hp;

        public int maxHp;

        public int attackHurt;

        public float attackRange;

        // 发射子弹的时间间隔
        public float shootInterval;

        public float shootTimer;


        public RoleInputComponent inputCom;

        public void Ctor() {
            attackRange = 4;
            attackHurt = 1;

            shootInterval = 2;
            shootTimer = 2;

        }

        public void SetTag(string tag) {
            go.tag = tag;
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

        // void OnCollisionEnter2D(Collision2D other) {
        //     if (other.gameObject.tag == "Mst") {
        //         Debug.Log("RoleEntity OnCollisionEnter2D");
        //     }

        //     Debug.Log(",,,,,ssssssss");
        // }
    }
}