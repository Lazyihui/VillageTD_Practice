using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace TD {


    public class Panel_ManifastElement : MonoBehaviour {

        [SerializeField] Image sp;
        [SerializeField] Button btn;
        [SerializeField] TextMeshProUGUI txt_Cost;
        public Action<int> OnClickHandle;
        public IDSignature idSig;
        public int resCount;
        public int typeID;

        public void Ctor() {
            btn.onClick.AddListener(() => {
                if (OnClickHandle != null) {
                    OnClickHandle.Invoke(typeID);
                }
            });
        }
        public void SetImage(Sprite image) {
            sp.sprite = image;
        }

        public void SetT_xtCost(int cost) {
            txt_Cost.text = cost.ToString();
        }
 
        public Vector3 GetPos() {
            Debug.Log(transform.position);
            return transform.position;
        }

        public void TearDown() {
            Destroy(gameObject);
        }
    }
}