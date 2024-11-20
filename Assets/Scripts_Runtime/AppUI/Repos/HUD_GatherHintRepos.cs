using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD {

    public class HUD_GatherHintRepos {

        Dictionary<IDSignature, HUD_GatherHint> all;
        HUD_GatherHint[] temArray;

        public HUD_GatherHintRepos() {
            all = new Dictionary<IDSignature, HUD_GatherHint>();
            temArray = new HUD_GatherHint[100];
        }

        public void Add(HUD_GatherHint entity) {
            all.Add(entity.idSig, entity);
        }
        public void Remove(HUD_GatherHint entity) {
            all.Remove(entity.idSig);
        }
        public int TakeAll(out HUD_GatherHint[] array) {
            if (all.Count > temArray.Length) {
                temArray = new HUD_GatherHint[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);
            array = temArray;
            return all.Count;
        }
        public bool TryGet(IDSignature idSig, out HUD_GatherHint entity) {
            return all.TryGetValue(idSig, out entity);
        }

        public void Clear() {
            all.Clear();
        }
    }
}