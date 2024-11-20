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
        public Panel_StageSelection panel_StageSelection;
        public Panel_Fail panel_Fail;

        public AssetsCore assetsCore;
        public TemplateCore templateCore;


        public Canvas screenCanvas;
        public Canvas worldCanvas;

        public Panel_ManifasetElementRepos panel_ManifasetElementRepos;
        public HUD_GatherHintRepos hud_GatherHintRepos;

        public UIContext() {
            panel_ManifasetElementRepos = new Panel_ManifasetElementRepos();
            hud_GatherHintRepos = new HUD_GatherHintRepos();
        }

        public void Inject(AssetsCore assetsCore, TemplateCore templateCore, Canvas screenCanvas, Canvas worldCanvas) {
            this.assetsCore = assetsCore;
            this.templateCore = templateCore;
            this.screenCanvas = screenCanvas;
            this.worldCanvas = worldCanvas;
        }
    }
}