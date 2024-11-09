using System;
using System.Collections.Generic;
using UnityEngine;


namespace TD {
    public class TowerEntity : MonoBehaviour {

        [SerializeField] SpriteRenderer spriteRenderer;

        [SerializeField] Collider2D colli;
        public string typeName;
        public IDSignature idSig;
        public PlaceConditionType placeConditionType;


        public int typeID;
        public int buildCost;
        public int hp;
        public int maxHp;



        public Vector2Int gridPos;


        // 启动了发射子弹
        public float shootTimer;

        public float shootInterval;

        public float attackHurt;

        public float attackRange;

        // 砍树时间
        public float cutTreeTime;

        public float cutTreeInterval;

        public int cutHurt;

        // bool 

        public TowerFSMComponent fsmCom;

        public void Ctor() {


        }

        public void SetCollider(bool isTriggers) {
            colli.isTrigger = isTriggers;
        }

        public void SetPos(Vector2Int pos) {
            transform.position = new Vector3(pos.x, pos.y, 0);
        }


        public void SetSprite(Sprite sprite) {
            spriteRenderer.sprite = sprite;
        }

        public void TearDown() {
            Destroy(gameObject);
        }


    }
}