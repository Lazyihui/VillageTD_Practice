using System;
using UnityEngine;
using UnityEngine.UI;


namespace TD {

    public class Panel_SelectCard : MonoBehaviour {

        [SerializeField] Image sp;

        public void Ctor() {

        }


        public void SetSprite(Sprite sprite) {
            sp.sprite = sprite;
        }


        public void Show() {
            gameObject.SetActive(true);
        }

        public void TearDown() {
            Destroy(gameObject);
        }
    }
}