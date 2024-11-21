using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TD {

    public class Panel_TowerInfo : MonoBehaviour {

        [SerializeField] TextMeshProUGUI txtName;
        [SerializeField] TextMeshProUGUI txtHp;
        [SerializeField] TextMeshProUGUI txtAttack;
        [SerializeField] TextMeshProUGUI txtCost;

        [SerializeField] Button btn_Remove;
        public Action OnRemoveClickHandle;
        [SerializeField] Button btn_Upgrade;
        public Action OnUpgradeClickHandle;
        [SerializeField] Button btn_Close;
        public Action OnCloseClickHandle;



        public void SetData(string name, int hp, float attack, int cost) {
            txtName.text = name;
            txtHp.text = "Hp:" + hp.ToString();
            txtAttack.text = "Att:" + attack.ToString();
            txtCost.text = "cost:" + cost.ToString();
        }

        public void Ctor() {
            txtName.text = "";
            txtHp.text = "";
            txtAttack.text = "";
            txtCost.text = "";

            btn_Remove.onClick.AddListener(() => {
                OnRemoveClickHandle?.Invoke();
            });
            btn_Upgrade.onClick.AddListener(() => {
                OnUpgradeClickHandle?.Invoke();
            });
            btn_Close.onClick.AddListener(() => {
                OnCloseClickHandle?.Invoke();
            });
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void TearDown() {
            Destroy(gameObject);
        }

        public void SetPos(Vector3 pos) {
            transform.position = pos;
        }

    }
}