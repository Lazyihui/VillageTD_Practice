using System;
using System.Collections.Generic;
using UnityEngine;


namespace TD {
    public class TowerEntity : MonoBehaviour {

        [SerializeField] SpriteRenderer spriteRenderer;

        public int typeID;

        public int id;

        public int hp;

        public int maxHp;


        public void Ctor() {

        }

        public void SetSprite(Sprite sprite) {
            spriteRenderer.sprite = sprite;
        }
        

    }
}