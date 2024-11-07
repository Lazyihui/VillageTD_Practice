using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public class TowerRepository {

        Dictionary<int, TowerEntity> all;
        Dictionary<Vector2Int, TowerEntity> posDict;

        TowerEntity[] temArray;


        public TowerRepository() {
            all = new Dictionary<int, TowerEntity>();
            posDict = new Dictionary<Vector2Int, TowerEntity>();
            temArray = new TowerEntity[100];
        }

        public void Add(TowerEntity entity) {
            all.Add(entity.id, entity);
            posDict.Add(entity.gridPos, entity);
        }

        public void Remove(TowerEntity entity) {
            all.Remove(entity.id);
            posDict.Remove(entity.gridPos);
        }

        public int TakeAll(out TowerEntity[] array) {
            if (all.Count > temArray.Length) {
                temArray = new TowerEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);
            array = temArray;

            return all.Count;
        }
        public bool TryGet(int id, out TowerEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public bool TryGetByPos(Vector2Int pos, out TowerEntity entity) {
            return posDict.TryGetValue(pos, out entity);
        }
    }
}