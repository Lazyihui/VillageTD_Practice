using System;
using UnityEngine;


namespace TD {

    public static class GameFactory {

        // Entity

        public static RoleEntity Role_Create(GameContext ctx, int typeID, Vector3 pos) {
            RoleTM tm;
            bool has = ctx.templateCore.ctx.Role_TryGet(typeID, out tm);
            GameObject prefab = ctx.assetsCore.Entity_GetRole();
            GameObject go = GameObject.Instantiate(prefab);
            RoleEntity entity = go.GetComponent<RoleEntity>();
            entity.idSig.entityType = EntityType.Role;
            entity.idSig.entityID = ctx.gameEntity.mstroleRecordID++;
            entity.typeID = tm.typeID;

            entity.Ctor();
            entity.SetCircleActive();

            entity.moveSpeed = tm.moveSpeed;
            entity.hp = tm.hp;
            entity.maxHp = tm.maxHp;

            entity.SetRbMass(tm.rbMass);
            entity.SetTag(tm.tag);

            // 要改
            entity.SetPos(pos);

            entity.SetSprite(tm.sp);
            // 
            entity.typeID = tm.typeID;
            return entity;
        }

        public static TowerEntity Tower_Create(GameContext ctx, int typeID, Vector2Int pos) {
            TowerTM tm;
            ctx.templateCore.ctx.Tower_TryGet(typeID, out tm);
            GameObject prefab = ctx.assetsCore.Entity_GetTower();
            GameObject go = GameObject.Instantiate(prefab);
            TowerEntity entity = go.GetComponent<TowerEntity>();

            entity.idSig.entityType = EntityType.Tower;
            entity.idSig.entityID = ctx.gameEntity.towerRecordID++;
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

            entity.Ctor();

            return entity;
        }

        public static MapEntity Map_Create(GameContext ctx, int typeID) {
            // 1. Get prefab
            GameObject prefab = ctx.assetsCore.Entity_GetMap();
            GameObject go = GameObject.Instantiate(prefab);

            MapEntity map = go.GetComponent<MapEntity>();

            map.idSig.entityType = EntityType.Map;
            map.idSig.entityID = ctx.gameEntity.stageID++;


            map.Ctor();

            // 2.Get MapGripElement prefavb
            GameObject groundPrefab = ctx.assetsCore.Entity_GetTileGround();
            MapGripElement ground = GameObject.Instantiate(groundPrefab, map.transform).GetComponent<MapGripElement>();

            GameObject treePrefab = ctx.assetsCore.Entity_GetTileTree();
            MapGripElement tree = GameObject.Instantiate(treePrefab, map.transform).GetComponent<MapGripElement>();


            map.Inject(ground, tree);

            return map;
        }

        public static TreeEntity Tree_Create(GameContext ctx, Vector2Int pos, int typeID) {
            TreeEntity entity = new TreeEntity();

            entity.pos = pos;
            entity.idSig.entityType = EntityType.Tree;

            entity.idSig.entityID = ctx.gameEntity.treeRecordID++;
            entity.typeID = typeID;
            entity.Ctor();

            return entity;


        }

        public static BulletEntity Bullet_Create(GameContext ctx, int typeID, Vector3 pos) {
            BulletTM tm;
            ctx.templateCore.ctx.Bullet_TryGet(typeID, out tm);
            GameObject prefab = ctx.assetsCore.Entity_GetBullet();
            GameObject go = GameObject.Instantiate(prefab);
            BulletEntity entity = go.GetComponent<BulletEntity>();
            entity.Ctor();
            entity.idSig.entityType = EntityType.Bullet;
            entity.idSig.entityID = ctx.gameEntity.bulletRecordID++;
            entity.typeID = tm.typeID;



            entity.SetPos(pos);
            entity.moveSpeed = tm.moveSpeed;

            return entity;
        }

        public static CaveEntity Cave_Create(GameContext ctx, int typeID, Vector3 pos) {
            CaveTM tm;
            ctx.templateCore.ctx.Cave_TryGet(typeID, out tm);
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

            entity.idSig.entityID = ctx.gameEntity.caveRecordID++;

            entity.SetPos(pos);

            return entity;
        }
    }

}