using System;
using System.Collections.Generic;

using UnityEngine;


public class UIEventCenter {

    public Action OnLoginClickHandle;

    public void OnLoginClick() {
        if (OnLoginClickHandle != null) {
            OnLoginClickHandle();
        }
    }
}