using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD {

    public static class TowerDoamin {

        public static TowerEntity Spawn(GameContext ctx, int typeID) {


            TowerTM tm;
            bool has = ctx.templateCore.ctx.Tower_TryGet(typeID, out tm);

            if (!has) {
                Debug.LogError("找不到这个塔");
                return null;
            }

            GameObject prefab = ctx.assetsCore.Entity_GetTower();

            GameObject go = GameObject.Instantiate(prefab);
            TowerEntity entity = go.GetComponent<TowerEntity>();

            entity.Ctor();
            entity.id = ctx.gameEntity.towerRecordID++;

            entity.typeID = tm.typeID;
            entity.hp = tm.hp;
            entity.maxHp = tm.maxHp;
            entity.SetSprite(tm.sprite);

            return null;
        }
    }
}