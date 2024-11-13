using System;
using UnityEngine;
using UnityEngine.UI;


namespace TD {


    public class Panel_ManifastElment : MonoBehaviour {

        [SerializeField] Image sp;

        public IDSignature idSig;

        public int resCount;

        public int typeID;

        public void Ctor() {

        }
        public void SetImage(Image image) {
            sp = image;
        }

    }
}