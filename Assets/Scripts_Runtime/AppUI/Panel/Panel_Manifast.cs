using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TD {

    public class Panel_Manifast : MonoBehaviour {


        [SerializeField] Transform group;

        [SerializeField] Panel_ManifastElment treeTower;

        [SerializeField] Panel_ManifastElment arrowTower;

        [SerializeField] Button btnHatChet;

        public Action<int> OnHatChetClickHandle;

        [SerializeField] Button btnTower;

        public Action<int> OnTowerClickHandle;

        public void Ctor() {

            btnHatChet.onClick.AddListener(() => {
                if (OnHatChetClickHandle != null) {
                    OnHatChetClickHandle.Invoke(treeTower.typeID);
                }
            });

            btnTower.onClick.AddListener(() => {
                if (OnTowerClickHandle != null) {
                    OnTowerClickHandle.Invoke(arrowTower.typeID);
                }
            });

        }

        public void Show() {
            gameObject.SetActive(true);
        }
    }
}