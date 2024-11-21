using System;
using System.Collections.Concurrent;
using UnityEngine;
using UnityEngine.UI;


namespace TD {

    public class HUD_InteractPopup : MonoBehaviour {

        public void Ctor() {

        }
        public Vector3 GetPos() {
            return transform.position;
        }
        public void SetPos(Vector3 pos) {
            transform.position = pos;
        }
        public void Show() {
            gameObject.SetActive(true);
        }
        public void TearDown() {
            Destroy(gameObject);
        }
    }
}