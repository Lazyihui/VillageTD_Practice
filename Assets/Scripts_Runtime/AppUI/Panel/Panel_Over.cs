using System;
using System.Collections.Generic;
using UnityEngine;


namespace TD {


    public class Panel_Over : MonoBehaviour {



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