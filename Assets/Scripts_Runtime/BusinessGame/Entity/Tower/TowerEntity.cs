using System;
using System.Collections.Generic;
using UnityEngine;


namespace TD {
    public class TowerEntity : MonoBehaviour {

        [SerializeField] SpriteRenderer spriteRenderer;

        [SerializeField] Collider2D colli;

        public int typeID;

        public int id;

        public int hp;

        public int maxHp;

        public Vector2Int gridPos;

        // Tower是否启动
        public bool isLive;


        public void Ctor() {
            if (this.typeID == TowerConst.BaseTower) {
                isLive = true;
            }

            isLive = false;

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