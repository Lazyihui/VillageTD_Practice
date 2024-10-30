using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TD {
    public class Panel_Login : MonoBehaviour {


        [SerializeField] Button btn_Login;


        public Action OnLoginClick;

        public void Ctor() {

            btn_Login.onClick.AddListener(() => {
                if (OnLoginClick != null) {
                    OnLoginClick.Invoke();
                }
            });

        }

        public void Show(){
            gameObject.SetActive(true);
        }

        public void TearDown(){
            GameObject.Destroy(gameObject);
        }

    }
}