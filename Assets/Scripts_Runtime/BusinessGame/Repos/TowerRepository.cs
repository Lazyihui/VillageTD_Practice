using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public class TowerRepository {

        Dictionary<int, TowerEntity> all;

        TowerEntity[] temArray;


        public TowerRepository() {
            all = new Dictionary<int, TowerEntity>();
            temArray = new TowerEntity[100];
        }

        public void Add(TowerEntity entity) {
            all.Add(entity.id, entity);
        }


        public void Remove(TowerEntity entity) {
            all.Remove(entity.id);
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
    }
}