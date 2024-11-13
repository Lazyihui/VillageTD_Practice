using System;
using UnityEngine;
using UnityEngine.UI;


namespace TD {


    public class Panel_ManifastElement : MonoBehaviour {

        [SerializeField] Image sp;
        [SerializeField] Button btn;
        public Action<IDSignature> OnClickHandle;
        public IDSignature idSig;
        public int resCount;
        public int typeID;

        public void Ctor() {
            btn.onClick.AddListener(() => {
                if (OnClickHandle != null) {
                    OnClickHandle.Invoke(idSig);
                }
            });
        }
        public void SetImage(Image image) {
            sp = image;
        }
        public Vector3 GetPos() {
            Debug.Log(transform.position);
            return transform.position;
        }
    }
}