using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TD {

    public class Panel_Manifast : MonoBehaviour {


        [SerializeField] Transform group;

        [SerializeField] Panel_ManifastElment treeTower;

        [SerializeField] Panel_ManifastElment tower;

        [SerializeField] Button btnHatChet;

        public Action OnHatChetClickHandle;

        [SerializeField] Button btnTower;

        public Action OnTowerClickHandle;

        public void Ctor() {

            btnHatChet.onClick.AddListener(() => {
                if (OnHatChetClickHandle != null) {
                    OnHatChetClickHandle.Invoke();
                }
            });

            btnTower.onClick.AddListener(() => {
                if (OnTowerClickHandle != null) {
                    OnTowerClickHandle.Invoke();
                }
            });

        }

        public void Show() {
            gameObject.SetActive(true);
        }
    }
}