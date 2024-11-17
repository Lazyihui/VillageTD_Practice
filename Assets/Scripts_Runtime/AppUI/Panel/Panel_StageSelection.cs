using System;
using System.Collections.Generic;
using UnityEngine;


namespace TD {
    public class Panel_StageSelection : MonoBehaviour {
        [SerializeField] public Transform group;

        [SerializeField] Panel_StageSelectionElement prefabele;


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