using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TD {

    public class Panel_TowerInfo : MonoBehaviour {

        [SerializeField] TextMeshProUGUI txtName;

        [SerializeField] TextMeshProUGUI txtHp;

        [SerializeField] TextMeshProUGUI txtAttack;

        [SerializeField] TextMeshProUGUI txtCost;


        // public void SetData(TowerEntity entity) {
        //     txtName.text = entity.name;
        //     txtHp.text = entity.hp.ToString();
        //     txtAttack.text = entity.attack.ToString();
        //     txtCost.text = entity.cost.ToString();
        // }

        public void Ctor() {
            txtName.text = "";
            txtHp.text = "";
            txtAttack.text = "";
            txtCost.text = "";
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void TearDown() {
            Destroy(gameObject);
        }


    }
}