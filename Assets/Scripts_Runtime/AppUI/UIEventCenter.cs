using System;
using System.Collections.Generic;

using UnityEngine;


public class UIEventCenter {

    public Action OnLoginClickHandle;

    public void OnLoginClick() {
        if (OnLoginClickHandle != null) {
            OnLoginClickHandle.Invoke();
        }
    }

    public Action OnHatChetClickHandle;

    public void OnHatChetClick() {
        if (OnHatChetClickHandle != null) {
            OnHatChetClickHandle.Invoke();
        }
    }

    public Action OnTowerClickHandle;

    public void OnTowerClick() {
        if (OnTowerClickHandle != null) {
            OnTowerClickHandle.Invoke();
        }
    }
}