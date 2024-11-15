using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TD {


    public class Panel_Fail : MonoBehaviour {

        [SerializeField] Button btnRestart;

        public Action OnRestartClickHandle;

        public void Ctor() {
            btnRestart.onClick.AddListener(() => {
                OnRestartClickHandle?.Invoke();
            });
        }


        public void Show() {
            gameObject.SetActive(true);
        }

        public void TearDown() {
            Destroy(gameObject);
        }



    }
}