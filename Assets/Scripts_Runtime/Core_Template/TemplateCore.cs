using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;


namespace TD {
    public class TemplateCore {

        public TemplateContext ctx;

        public TemplateCore() {
            ctx = new TemplateContext();
        }


        public async Task LoadAll(GameContext ctx) {
            {
                AssetLabelReference labelReference = new AssetLabelReference();

                labelReference.labelString = "So_Role";
                var handle = Addressables.LoadAssetsAsync<RoleSO>(labelReference, null);

                var all = await handle.Task;

                foreach (var so in all) {
                    var tm = so.tm;
                    ctx.templateCore.ctx.Role_Add(tm);
                }

                ctx.templateCore.ctx.rolePtr = handle;
            }
            {
                AssetLabelReference labelReference = new AssetLabelReference();

                labelReference.labelString = "So_Tower";
                var handle = Addressables.LoadAssetsAsync<TowerSO>(labelReference, null);

                var all = await handle.Task;

                foreach (var so in all) {
                    var tm = so.tm;
                    ctx.templateCore.ctx.Tower_Add(tm);
                }

                ctx.templateCore.ctx.towerPtr = handle;
            }
        }

        public void UnLoadAll() {
            if (ctx.rolePtr.IsValid()) {
                Addressables.Release(ctx.rolePtr);
            }

            if (ctx.towerPtr.IsValid()) {
                Addressables.Release(ctx.towerPtr);
            }
        }



    }
}