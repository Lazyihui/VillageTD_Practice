using System;
using System.Collections.Generic;
using UnityEngine;


namespace TD {


    public class Panel_Victory : MonoBehaviour {



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