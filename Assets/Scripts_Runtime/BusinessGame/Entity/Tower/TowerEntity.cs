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


        public void Ctor() {

        }

        public void SetCollider() {
            if(typeID==TowerConst.BaseTower){
                colli.enabled = false;
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