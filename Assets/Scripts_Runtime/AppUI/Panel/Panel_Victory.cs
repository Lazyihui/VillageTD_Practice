using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TD {


    public class Panel_Victory : MonoBehaviour {

        [SerializeField] Button btnRestart;
        [SerializeField] Button btnNext;
        public Action OnRestartClickHandle;
        public Action OnNextClickHandle;


        public void Ctor() {
            btnRestart.onClick.AddListener(() => {
                OnRestartClickHandle?.Invoke();
            });
            btnNext.onClick.AddListener(() => {
                OnNextClickHandle?.Invoke();
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