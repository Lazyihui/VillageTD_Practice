using System;
using System.Collections.Generic;
using UnityEngine;


namespace TD {

    public class UIContext {

        public Panel_Login panel_Login;
        public Panel_Manifast panel_Manifast;
        public Panel_ResourceInfo panel_ResourceInfo;
        public Panel_SelectCard panel_SelectCard;
        public Panel_TowerInfo panel_TowerInfo;
        public Panel_Over panel_Over;

        public AssetsCore assetsCore;
        public TemplateCore templateCore;


        public Canvas screenCanvas;
        public Canvas worldCanvas;

        public UIContext() {

        }

        public void Inject(AssetsCore assetsCore, TemplateCore templateCore, Canvas screenCanvas, Canvas worldCanvas) {
            this.assetsCore = assetsCore;
            this.templateCore = templateCore;
            this.screenCanvas = screenCanvas;
            this.worldCanvas = worldCanvas;
        }
    }
}