using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public class CaveRepository {

        Dictionary<int, CaveEntity> all;

        CaveEntity[] temArray;


        public CaveRepository() {
            all = new Dictionary<int, CaveEntity>();
            temArray = new CaveEntity[100];
        }

        public void Add(CaveEntity entity) {
            Debug.Log(entity.id);
            all.Add(entity.id, entity);
        }


        public void Remove(CaveEntity entity) {
            all.Remove(entity.id);
        }

        public int TakeAll(out CaveEntity[] array) {
            if (all.Count > temArray.Length) {
                temArray = new CaveEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);
            array = temArray;

            return all.Count;
        }
        public bool TryGet(int id, out CaveEntity entity) {
            return all.TryGetValue(id, out entity);
        }
    }
}