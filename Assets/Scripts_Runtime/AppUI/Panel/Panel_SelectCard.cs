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

        public void SetPos(Vector2Int pos){
            Vector3 newPos = new Vector3(pos.x, pos.y, 0);
            transform.position = newPos;
        }
        public void Show() {
            gameObject.SetActive(true);
        }

        public void TearDown() {
            Destroy(gameObject);
        }
    }
}