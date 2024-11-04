using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TD {

    public class Panel_Manifast : MonoBehaviour {

        [SerializeField] Button btnHatChet;

        public Action OnHatChetClickHandle;


        public void Ctor() {

            btnHatChet.onClick.AddListener(() => {
                if (OnHatChetClickHandle != null) {
                    OnHatChetClickHandle.Invoke();
                }
            });


        }

        public void Show(){
            gameObject.SetActive(true);
        }
    }
}