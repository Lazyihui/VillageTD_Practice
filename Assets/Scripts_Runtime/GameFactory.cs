using System;
using UnityEngine;


namespace TD {

    public static class GameFactory {

        // Entity

        public static RoleEntity Role_Create(GameContext ctx, int typeID, Vector3 pos, RoleSpawnTM spawnTM) {
            RoleTM tm;
            bool has = ctx.templateCore.Role_TryGet(typeID, out tm);
            if (!has) {
                Debug.LogError("Role_Create: tm is null" + typeID);
                return null;
            }
            GameObject prefab = ctx.assetsCore.Entity_GetRole();
            GameObject go = GameObject.Instantiate(prefab);
            RoleEntity entity = go.GetComponent<RoleEntity>();
            entity.idSig.entityType = EntityType.Role;
            entity.idSig.entityID = ctx.idService.mstroleRecordID++;
            entity.typeID = tm.typeID;

            entity.fsmCom = tm.fsmCom;

            entity.Ctor();
            entity.SetCircleActive();

            entity.moveSpeed = tm.moveSpeed;
            entity.hp = tm.hp;
            entity.maxHp = tm.maxHp;

            entity.SetRbMass(tm.rbMass);
            entity.SetTag(tm.tag);

            entity.TF_SetPostion(spawnTM.position);
            entity.TF_SetRotation(spawnTM.rotation);

            entity.SetSprite(tm.sp);
            return entity;
        }
        // mst
        public static RoleEntity Mst_Create(GameContext ctx, int typeID, Vector3 pos, Vector2[] path) {
            RoleTM tm;
            bool has = ctx.templateCore.Role_TryGet(typeID, out tm);
            if (!has) {
                Debug.LogError("Mst_Create: tm is null" + typeID);
                return null;
            }
            GameObject prefab = ctx.assetsCore.Entity_GetRole();
            GameObject go = GameObject.Instantiate(prefab);
            RoleEntity entity = go.GetComponent<RoleEntity>();
            entity.idSig.entityType = EntityType.Role;
            entity.idSig.entityID = ctx.idService.mstroleRecordID++;
            entity.typeID = tm.typeID;
            entity.fsmCom = tm.fsmCom;

            entity.Ctor();
            entity.SetCircleActive();

            entity.moveSpeed = tm.moveSpeed;
            entity.hp = tm.hp;
            entity.maxHp = tm.maxHp;

            entity.SetRbMass(tm.rbMass);
            entity.SetTag(tm.tag);

            entity.SetPos(pos);

            entity.pathCom.SetPath(path);

            entity.SetSprite(tm.sp);
            return entity;
        }
        public static TowerEntity Tower_Create_hasPos(GameContext ctx, int typeID, Vector2Int pos, IDSignature idsigMap, TowerSpawnTM spawnTM) {
            TowerTM tm;
            bool has = ctx.templateCore.Tower_TryGet(typeID, out tm);
            if (!has) {
                Debug.LogError("Tower_Create_hasPos: tm is null" + typeID);
                return null;
            }
            GameObject prefab = ctx.assetsCore.Entity_GetTower();
            GameObject go = GameObject.Instantiate(prefab);
            TowerEntity entity = go.GetComponent<TowerEntity>();

            entity.idSig.entityType = EntityType.Tower;
            entity.idSig.entityID = ctx.idService.towerRecordID++;
            entity.typeName = tm.typeName;

            entity.gridPos = pos;
            entity.placeConditionType = tm.placeConditionType;

            entity.hp = tm.hp;
            entity.maxHp = tm.maxHp;
            entity.buildCost = tm.buildCost;
            entity.shootInterval = tm.shootInterval;
            entity.shootTimer = tm.shootTimer;

            entity.attackHurt = tm.attackHurt;
            entity.attackRange = tm.attackRange;
            // tree
            entity.cutTreeTime = tm.cutTreeTime;
            entity.cutTreeInterval = tm.cutTreeInterval;
            entity.cutHurt = tm.cutHurt;

            entity.typeID = tm.typeID;
            entity.SetSprite(tm.sprite);
            entity.SetPos(pos);
            entity.fsmCom = tm.fsmCom;
            entity.SetCollider(tm.isTrigger);
            entity.SetCircleObjActive(false);

            entity.TF_SetPostion(spawnTM.position);
            entity.TF_SetRotation(spawnTM.rotation);


            entity.idsigMap = idsigMap;

            entity.Ctor();
            return entity;
        }
        public static TowerEntity Tower_Create(GameContext ctx, int typeID, Vector2Int pos, IDSignature idsigMap) {
            TowerTM tm;
            ctx.templateCore.Tower_TryGet(typeID, out tm);
            if (tm == null) {
                Debug.LogError("Tower_Create: tm is null" + typeID);
                return null;
            }
            GameObject prefab = ctx.assetsCore.Entity_GetTower();
            GameObject go = GameObject.Instantiate(prefab);
            TowerEntity entity = go.GetComponent<TowerEntity>();

            entity.idSig.entityType = EntityType.Tower;
            entity.idSig.entityID = ctx.idService.towerRecordID++;

            entity.typeName = tm.typeName;

            entity.gridPos = pos;
            entity.placeConditionType = tm.placeConditionType;

            entity.hp = tm.hp;
            entity.maxHp = tm.maxHp;
            entity.buildCost = tm.buildCost;
            entity.shootInterval = tm.shootInterval;
            entity.shootTimer = tm.shootTimer;

            entity.attackHurt = tm.attackHurt;
            entity.attackRange = tm.attackRange;
            // tree
            entity.cutTreeTime = tm.cutTreeTime;
            entity.cutTreeInterval = tm.cutTreeInterval;
            entity.cutHurt = tm.cutHurt;

            entity.typeID = tm.typeID;
            entity.SetSprite(tm.sprite);
            entity.SetPos(pos);
            entity.fsmCom = tm.fsmCom;
            entity.SetCollider(tm.isTrigger);
            entity.SetCircleObjActive(false);

            entity.idsigMap = idsigMap;
            entity.Ctor();
            return entity;
        }



        public static MapEntity Map_Create(GameContext ctx, GameObject model) {
            // 1. Get prefab
            GameObject go = GameObject.Instantiate(model);
            MapEntity map = go.GetComponent<MapEntity>();
            // GameObject prefab = ctx.assetsCore.Entity_GetMap();
            // GameObject go = GameObject.Instantiate(prefab);
            map.idSig.entityType = EntityType.Map;
            map.idSig.entityID = ctx.idService.stageRecordID++;
            map.Ctor();

            return map;
        }

        public static TreeEntity Tree_Create(GameContext ctx, Vector2Int pos, int typeID, IDSignature idsigMap) {
            TreeEntity entity = new TreeEntity();

            entity.pos = pos;
            entity.idSig.entityType = EntityType.Tree;
            entity.idsigMap = idsigMap;

            entity.idSig.entityID = ctx.idService.treeRecordID++;
            entity.typeID = typeID;
            entity.Ctor();

            return entity;


        }

        public static BulletEntity Bullet_Create(GameContext ctx, int typeID, Vector3 pos) {
            BulletTM tm;
            bool has = ctx.templateCore.Bullet_TryGet(typeID, out tm);
            if (!has) {
                Debug.LogError("Bullet_Create: tm is null" + typeID);
                return null;
            }

            GameObject prefab = ctx.assetsCore.Entity_GetBullet();
            GameObject go = GameObject.Instantiate(prefab);
            BulletEntity entity = go.GetComponent<BulletEntity>();
            entity.Ctor();
            entity.idSig.entityType = EntityType.Bullet;
            entity.idSig.entityID = ctx.idService.bulletRecordID++;
            entity.typeID = tm.typeID;



            entity.SetPos(pos);
            entity.moveSpeed = tm.moveSpeed;

            return entity;
        }

        public static CaveEntity Cave_Create(GameContext ctx, int typeID, CaveSpawnTM spawnTM) {
            CaveTM tm;
            bool has = ctx.templateCore.Cave_TryGet(typeID, out tm);
            if (!has) {
                Debug.LogError("Cave_Create: tm is null" + typeID);
                return null;
            }
            GameObject prefab = ctx.assetsCore.Entity_GetCave();
            GameObject go = GameObject.Instantiate(prefab);
            CaveEntity entity = go.GetComponent<CaveEntity>();

            entity.idSig.entityType = EntityType.Cave;
            entity.Ctor();
            entity.typeID = tm.typeID;

            entity.caveSpawnTime = tm.caveSpawnTime;
            entity.caveSpawnInterval = tm.caveSpawnInterval;

            entity.isLive = tm.isLive;
            entity.activeTimer = tm.activeTimer;
            entity.activeInterval = tm.activeInterval;
            entity.spawnMaxCount = tm.spawnMaxCount;

            entity.idSig.entityID = ctx.idService.caveRecordID++;

            entity.mstMovePath = tm.mstMovePath;

            entity.TF_SetPostion(spawnTM.position);
            entity.TF_SetRotation(spawnTM.rotation);

            entity.mstMovePath = spawnTM.path;

            return entity;
        }
    }

}