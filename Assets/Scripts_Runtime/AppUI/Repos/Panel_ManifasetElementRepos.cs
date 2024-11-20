using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD {

    public class Panel_ManifasetElementRepos {

        Dictionary<IDSignature, Panel_ManifastElement> all;
        Panel_ManifastElement[] temArray;

        public Panel_ManifasetElementRepos() {
            all = new Dictionary<IDSignature, Panel_ManifastElement>();
            temArray = new Panel_ManifastElement[100];
        }

        public void Add(Panel_ManifastElement entity) {
            all.Add(entity.idSig, entity);
        }
        public void Remove(Panel_ManifastElement entity) {
            all.Remove(entity.idSig);
        }
        public int TakeAll(out Panel_ManifastElement[] array) {
            if (all.Count > temArray.Length) {
                temArray = new Panel_ManifastElement[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);
            array = temArray;
            return all.Count;
        }
        public bool TryGet(IDSignature idSig, out Panel_ManifastElement entity) {
            return all.TryGetValue(idSig, out entity);
        }

        public void Clear() {
            all.Clear();
        }
    }
}