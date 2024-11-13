using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD {

    public class UIReposRepository {

        Dictionary<IDSignature, Panel_ManifastElment> all;
        Panel_ManifastElment[] temArray;

        public UIReposRepository() {
            all = new Dictionary<IDSignature, Panel_ManifastElment>();
            temArray = new Panel_ManifastElment[100];
        }


        #region  Panel_ManifastElment
        public void Add(Panel_ManifastElment entity) {
            all.Add(entity.idSig, entity);
        }
        public void Remove(Panel_ManifastElment entity) {
            all.Remove(entity.idSig);
        }
        public int TakeAll(out Panel_ManifastElment[] array) {
            if (all.Count > temArray.Length) {
                temArray = new Panel_ManifastElment[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);
            array = temArray;
            return all.Count;
        }
        public bool TryGet(IDSignature idSig, out Panel_ManifastElment entity) {
            return all.TryGetValue(idSig, out entity);
        }
    }
    #endregion
}