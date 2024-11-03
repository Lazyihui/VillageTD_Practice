using System;
using UnityEngine;


namespace TD {

    public static class GameFactory {

        // Entity

        public static RoleEntity Role_Create(GameContext ctx, int typeID) {
            RoleTM tm;
            bool has = ctx.templateCore.ctx.Role_TryGet(typeID, out tm);
            GameObject prefab = ctx.assetsCore.Entity_GetRole();
            GameObject go = GameObject.Instantiate(prefab);
            RoleEntity entity = go.GetComponent<RoleEntity>();
            entity.Ctor();
            entity.typeID = tm.typeID;
            return entity;
        }

        public static TowerEntity Tower_Create(GameContext ctx, int typeID) {
            TowerTM tm;
            ctx.templateCore.ctx.Tower_TryGet(typeID, out tm);
            GameObject prefab = ctx.assetsCore.Entity_GetTower();
            GameObject go = GameObject.Instantiate(prefab);
            TowerEntity entity = go.GetComponent<TowerEntity>();
            entity.Ctor();
            entity.id = ctx.gameEntity.towerRecordID++;

            entity.hp = tm.hp;
            entity.maxHp = tm.maxHp;
            entity.typeID = tm.typeID;
            entity.SetSprite(tm.sprite);

            return entity;
        }

        public static MapEntity Map_Create(GameContext ctx, int typeID) {
            // 1. Get prefab
            GameObject prefab = ctx.assetsCore.Entity_GetMap();
            GameObject go = GameObject.Instantiate(prefab);

            MapEntity map = go.GetComponent<MapEntity>();
            map.Ctor();
            map.stageID = typeID;

            // 2.Get MapGripElement prefavb
            GameObject groundPrefab = ctx.assetsCore.Entity_GetTileGround();
            MapGripElement ground = GameObject.Instantiate(groundPrefab,map.transform).GetComponent<MapGripElement>();

            GameObject treePrefab = ctx.assetsCore.Entity_GetTileTree();
            MapGripElement tree = GameObject.Instantiate(treePrefab,map.transform).GetComponent<MapGripElement>();

            
            map.Inject(ground,tree);

            return map;
        }
    }
}