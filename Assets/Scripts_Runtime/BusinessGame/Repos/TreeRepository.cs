using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public class TreeRepository {

        Dictionary<int, TreeEntity> all;

        TreeEntity[] temArray;


        public TreeRepository() {
            all = new Dictionary<int, TreeEntity>();
            temArray = new TreeEntity[100];
        }

        public void Add(TreeEntity entity) {
            all.Add(entity.id, entity);
        }


        public void Remove(TreeEntity entity) {
            all.Remove(entity.id);
        }

        public int TakeAll(out TreeEntity[] array) {
            if (all.Count > temArray.Length) {
                temArray = new TreeEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);
            array = temArray;

            return all.Count;
        }
        public bool TryGet(int id, out TreeEntity entity) {
            return all.TryGetValue(id, out entity);
        }
    }
}