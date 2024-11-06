using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



namespace TD {


    public class Panel_ResourceInfo : MonoBehaviour {

        [SerializeField] TextMeshProUGUI txtResCount;

        public void Ctor() {
        }

        public void SetResCount(int count) {
            txtResCount.text = count.ToString();
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void TearDown() {
            Destroy(gameObject);
        }


    }
}