using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public class RoleRepository {

        Dictionary<int, RoleEntity> all;

        RoleEntity[] temArray;


        public RoleRepository() {
            all = new Dictionary<int, RoleEntity>();
            temArray = new RoleEntity[100];
        }

        public void Add(RoleEntity entity) {
            all.Add(entity.id, entity);
        }


        public void Remove(RoleEntity entity) {
            all.Remove(entity.id);
        }

        public int TakeAll(out RoleEntity[] array) {
            if (all.Count > temArray.Length) {
                temArray = new RoleEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);
            array = temArray;

            return all.Count;
        }


    }
}