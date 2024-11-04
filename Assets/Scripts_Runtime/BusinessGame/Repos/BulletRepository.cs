using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public class BulletRepository {

        Dictionary<int, BulletEntity> all;

        BulletEntity[] temArray;


        public BulletRepository() {
            all = new Dictionary<int, BulletEntity>();
            temArray = new BulletEntity[100];
        }

        public void Add(BulletEntity entity) {
            all.Add(entity.id, entity);
        }


        public void Remove(BulletEntity entity) {
            all.Remove(entity.id);
        }

        public int TakeAll(out BulletEntity[] array) {
            if (all.Count > temArray.Length) {
                temArray = new BulletEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);
            array = temArray;

            return all.Count;
        }
        public bool TryGet(int id, out BulletEntity entity) {
            return all.TryGetValue(id, out entity);
        }
    }
}