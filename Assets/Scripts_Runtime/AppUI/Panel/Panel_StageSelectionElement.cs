using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TD {
    public class Panel_StageSelectionElement : MonoBehaviour {

        [SerializeField] Button btn;

        public Action<int> OnBtnClickHandle;
        public int stageID;

        public void Ctor() {
            btn.onClick.AddListener(() => {
                OnBtnClickHandle?.Invoke(stageID);
            });
        }

    }
}