using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TD {

    public class Panel_Manifast : MonoBehaviour {


        [SerializeField] public Transform group;

        public void Ctor() {
        }


        public void Panel_Manifast_AddElement(Panel_ManifastElement entity) {


        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void TearDown() {
            Destroy(gameObject);
        }


    }
}