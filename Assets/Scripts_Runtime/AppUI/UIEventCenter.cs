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

    public Action<int> OnHatChetClickHandle;

    public void OnHatChetClick(int typeID) {
        if (OnHatChetClickHandle != null) {
            OnHatChetClickHandle.Invoke(typeID);
        }
    }

    public Action<int> OnTowerClickHandle;

    public void OnTowerClick(int typeID) {
        if (OnTowerClickHandle != null) {
            OnTowerClickHandle.Invoke(typeID);
        }
    }
}