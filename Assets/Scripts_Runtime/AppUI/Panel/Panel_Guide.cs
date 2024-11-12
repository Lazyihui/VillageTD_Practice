using System;
using UnityEngine;
using TMPro;


namespace TD {
    public class Panel_Guide : MonoBehaviour {

        [SerializeField] TextMeshProUGUI txt_Content;

        public void Ctor() {

        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void TearDown() {
            Destroy(gameObject);
        }


    }
}


