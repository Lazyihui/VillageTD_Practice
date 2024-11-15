using System;
using System.Collections.Generic;
using UnityEngine;


namespace TD.UIInternal {

    public class UIContext {

        public Panel_Login panel_Login;
        public Panel_Manifast panel_Manifast;
        public Panel_ResourceInfo panel_ResourceInfo;
        public Panel_SelectCard panel_SelectCard;
        public Panel_TowerInfo panel_TowerInfo;
        public Panel_Victory panel_Victory;
        public Panel_Guide panel_Guide;
        public Panel_ManifastInfo panel_ManifastInfo;
        public Panel_Notice panel_Notice;
        public Panel_Fail panel_Fail;
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