using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public class CaveRepository {

        Dictionary<IDSignature, CaveEntity> all;

        CaveEntity[] temArray;


        public CaveRepository() {
            all = new Dictionary<IDSignature, CaveEntity>();
            temArray = new CaveEntity[100];
        }

        public void Add(CaveEntity entity) {
            all.Add(entity.idSig, entity);
        }


        public void Remove(CaveEntity entity) {
            all.Remove(entity.idSig);
        }

        public int TakeAll(out CaveEntity[] array) {
            if (all.Count > temArray.Length) {
                temArray = new CaveEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);
            array = temArray;

            return all.Count;
        }
        public bool TryGet(IDSignature idSig, out CaveEntity entity) {
            return all.TryGetValue(idSig, out entity);
        }
        public void Clear() {
            all.Clear();
        }
    }
}