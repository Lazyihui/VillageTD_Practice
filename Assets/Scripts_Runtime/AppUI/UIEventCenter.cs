using System;
using System.Collections.Generic;

using UnityEngine;

namespace TD {

    public class UIEventCenter {

        public Action OnLoginClickHandle;

        public void OnLoginClick() {
            if (OnLoginClickHandle != null) {
                OnLoginClickHandle.Invoke();
            }
        }

        public Action<int> OnMainfastClickHandle;
        public void OnMainfastClickElement(int typeID) {
            if (OnMainfastClickHandle != null) {
                OnMainfastClickHandle.Invoke(typeID);
            }
        }

        public Action OnRestartClickHandle;
        public void OnRestartClick() {
            if (OnRestartClickHandle != null) {
                OnRestartClickHandle.Invoke();
            }
        }

        public Action OnNextClickHandle;
        public void OnNextClick() {
            if (OnNextClickHandle != null) {
                OnNextClickHandle.Invoke();
            }
        }

    }
}