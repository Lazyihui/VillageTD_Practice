using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using TD.TemplateInternal;


namespace TD {
    public class TemplateCore {

        public TemplateContext ctx;

        public TemplateCore() {
            ctx = new TemplateContext();
        }

        public bool Stage_TryGet(int typeID, out StageTM stage) {
            return ctx.stages.TryGetValue(typeID, out stage);
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
            {
                AssetLabelReference labelReference = new AssetLabelReference();

                labelReference.labelString = "So_Bullet";
                var handle = Addressables.LoadAssetsAsync<BulletSO>(labelReference, null);

                var all = await handle.Task;

                foreach (var so in all) {
                    var tm = so.tm;
                    ctx.templateCore.ctx.Bullet_Add(tm);
                }

                ctx.templateCore.ctx.bulletPtr = handle;
            }
            {
                AssetLabelReference labelReference = new AssetLabelReference();

                labelReference.labelString = "So_Tree";
                var handle = Addressables.LoadAssetsAsync<TreeSO>(labelReference, null);

                var all = await handle.Task;

                foreach (var so in all) {
                    var tm = so.tm;
                    ctx.templateCore.ctx.Tree_Add(tm);
                }

                ctx.templateCore.ctx.treePtr = handle;
            }
            {
                AssetLabelReference labelReference = new AssetLabelReference();

                labelReference.labelString = "So_PanelCard";
                var handle = Addressables.LoadAssetsAsync<PanelCardSO>(labelReference, null);
                var all = await handle.Task;

                foreach (var so in all) {
                    var tm = so.tm;
                    ctx.templateCore.ctx.PanelCard_Add(tm);
                }
                ctx.templateCore.ctx.panelCardPtr = handle;
            }

            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "So_Cave";

                var handle = Addressables.LoadAssetsAsync<CaveSO>(labelReference, null);
                var all = await handle.Task;

                foreach (var so in all) {
                    var tm = so.tm;
                    ctx.templateCore.ctx.Cave_Add(tm);
                }

                ctx.templateCore.ctx.cavePtr = handle;
            }
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "So_Stage";

                var handle = Addressables.LoadAssetsAsync<StageSO>(labelReference, null);
                var all = await handle.Task;

                foreach (var so in all) {
                    var tm = so.tm;
                    ctx.templateCore.ctx.Stage_Add(tm);
                }

                ctx.templateCore.ctx.stagePtr = handle;
            }
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "So_Map";

                var hanle = Addressables.LoadAssetsAsync<MapSO>(labelReference, null);
                var all = await hanle.Task;

                foreach(var so in all) {
                    var tm = so.tm;
                    ctx.templateCore.ctx.maps.Add(tm.typeID, tm);
                }

                ctx.templateCore.ctx.mapPtr = hanle;
            }
        }
        // 找种类的Role
        public bool Role_TryGet(int typeID, out RoleTM role) {
            return ctx.roles.TryGetValue(typeID, out role);
        }

        public bool Tower_TryGet(int typeID, out TowerTM tower) {
            return ctx.towers.TryGetValue(typeID, out tower);
        }

        public bool Bullet_TryGet(int typeID, out BulletTM bullet) {
            return ctx.bullets.TryGetValue(typeID, out bullet);
        }

        public bool Tree_TryGet(int typeID, out TreeTM tree) {
            return ctx.trees.TryGetValue(typeID, out tree);
        }

        public bool PanelCard_TryGet(int typeID, out PanelCardTM panelCard) {
            return ctx.panelCards.TryGetValue(typeID, out panelCard);
        }

        public bool Cave_TryGet(int typeID, out CaveTM cave) {
            return ctx.caves.TryGetValue(typeID, out cave);
        }

        
        public void UnLoadAll() {
            if (ctx.rolePtr.IsValid()) {
                Addressables.Release(ctx.rolePtr);
            }

            if (ctx.towerPtr.IsValid()) {
                Addressables.Release(ctx.towerPtr);
            }

            if (ctx.bulletPtr.IsValid()) {
                Addressables.Release(ctx.bulletPtr);
            }
            if (ctx.treePtr.IsValid()) {
                Addressables.Release(ctx.treePtr);
            }
            if (ctx.panelCardPtr.IsValid()) {
                Addressables.Release(ctx.panelCardPtr);
            }
            if (ctx.cavePtr.IsValid()) {
                Addressables.Release(ctx.cavePtr);
            }
        }



    }
}