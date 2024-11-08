using System;
using System.Collections.Generic;
using UnityEngine;


namespace TD {
    public class TowerEntity : MonoBehaviour {

        [SerializeField] SpriteRenderer spriteRenderer;

        [SerializeField] Collider2D colli;

        public IDSignature idSig;
        public int typeID;

        public PlaceConditionType placeConditionType;

        public int hp;
        public int maxHp;

        public Vector2Int gridPos;

        // Tower是否启动
        public bool isLive;

        // 启动了发射子弹
        public float shootTimer;


        public float shootInterval;

        public float attackHurt;

        public float attackRange;

        // 砍树时间
        public float cutTreeTime;

        public float cutTreeInterval;

        public int cutHurt;


        public void Ctor() {

        }

        public void SetPos(Vector2Int pos) {
            transform.position = new Vector3(pos.x, pos.y, 0);
        }

        public void SetCollider() {
            if (typeID == TowerConst.BaseTower) {
                colli.isTrigger = true;
            }
        }

        public void SetSprite(Sprite sprite) {
            spriteRenderer.sprite = sprite;
        }

        public void TearDown() {
            Destroy(gameObject);
        }


    }
}