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
        public void SetHint(float time, float allTime) {
            if (allTime == 0) {
                Debug.Log(time + " " + allTime);
                imgHint.fillAmount = 0;
                imgBG.fillAmount = 0;
                return;
            }

            // time =0;一开始 time++;
            imgHint.fillAmount = time / allTime;
        }

        public void SetPos(Vector3 pos) {
            transform.position = pos;
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void TearDown() {
            Destroy(gameObject);
        }

    }
}