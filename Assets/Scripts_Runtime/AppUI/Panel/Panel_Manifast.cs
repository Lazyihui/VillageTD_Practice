using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TD {

    public class Panel_Manifast : MonoBehaviour {


        [SerializeField] Transform group;

        [SerializeField] Panel_ManifastElment treeTower;

        [SerializeField] Panel_ManifastElment arrowTower;

        [SerializeField] Panel_ManifastElment PlantTree;
        [SerializeField] Button btnHatChet;

        public Action<int> OnHatChetClickHandle;

        [SerializeField] Button btnTower;

        public Action<int> OnTowerClickHandle;

        [SerializeField] Button btnPlantTree;

        public Action<int> OnPlantTreeClickHandle;

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

            btnPlantTree.onClick.AddListener(() => {
                if (OnPlantTreeClickHandle != null) {
                    OnPlantTreeClickHandle.Invoke(PlantTree.typeID);
                }
            });

        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void TearDown() {

            gameObject.SetActive(false);
        }

        public Vector3 GetPosTower() {
            return arrowTower.transform.position;
        }

        public Vector3 GetPosTree() {
            return treeTower.transform.position;
        }

        public Vector3 GetPosPlantTree() {
            return PlantTree.transform.position;
        }
    }
}