using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TD {

    public class Panel_Manifast : MonoBehaviour {


        [SerializeField] Transform group;

        [SerializeField] Panel_ManifastElment prefabEle;



        public void Ctor() {

        }


        public void AddElment(int typeID, Image image) {
            Panel_ManifastElment ele = GameObject.Instantiate(prefabEle, group);
            ele.Ctor();
            ele.typeID = typeID;
            ele.SetImage(image);
            ele.OnHatChetClickHandle += () => {
                Debug.Log("HatChet Click");
            };
        }

        public void Show() {
            gameObject.SetActive(true);
        }
    }
}