using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TD {
    public class Panel_StageSelectionElement : MonoBehaviour {

        [SerializeField] Button btn;

        [SerializeField] TextMeshProUGUI txtStageName;

        public Action<int> OnBtnClickHandle;
        public int stageID;

        public void SetTxt(string txt) {
            txtStageName.text = txt;
        }

        public void Ctor() {
            btn.onClick.AddListener(() => {
                OnBtnClickHandle?.Invoke(stageID);
            });
        }

    }
}