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

                labelReference.labelString = "RoleSO";
                var handle = Addressables.LoadAssetsAsync<RoleSO>(labelReference, null);

                var all = await handle.Task;
                foreach (var item in all) {
                    ctx.templateCore.ctx.roles.Add(item.tm.typeID, item.tm);
                }

                ctx.templateCore.ctx.rolePtr = handle;
            }
        }

        public void UnLoadAll() {
            if (ctx.rolePtr.IsValid()) {
                Addressables.Release(ctx.rolePtr);
            }
        }



    }
}