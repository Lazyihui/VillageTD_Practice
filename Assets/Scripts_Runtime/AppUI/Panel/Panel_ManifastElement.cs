using System;
using UnityEngine;
using UnityEngine.UI;


namespace TD {


    public class Panel_ManifastElement : MonoBehaviour {

        [SerializeField] Image sp;
        [SerializeField] Button btn;
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
        public Vector3 GetPos() {
            Debug.Log(transform.position);
            return transform.position;
        }
    }
}