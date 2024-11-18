using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TD {

    public class HUD_GatherHint : MonoBehaviour {
        [SerializeField] Image imgBG;
        [SerializeField] Image imgHint;


        public void Ctor() {
        }
    
        // TODO: 可能要把塔的血量 和 树的采集速度分开
        public void SetHint(float hp, float maxHp) {
            if()

        }



        public void Show() {
            gameObject.SetActive(true);
        }

        public void TearDown() {
            Destroy(gameObject);
        }

    }
}