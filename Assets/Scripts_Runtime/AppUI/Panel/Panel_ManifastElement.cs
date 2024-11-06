using System;
using UnityEngine;
using UnityEngine.UI;


namespace TD {


    public class Panel_ManifastElment : MonoBehaviour {

        [SerializeField] Image sp;

        [SerializeField] Button btnHatChet;

        public Action OnHatChetClickHandle;

        public int typeID;
        public void Ctor() {

            btnHatChet.onClick.AddListener(() => {
                if (OnHatChetClickHandle != null) {
                    OnHatChetClickHandle.Invoke();
                }
            });

        }
       

        public void SetImage(Image image) {
            sp = image;
        }


    }
}