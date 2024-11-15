using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TD {

    public class TreeRepository {

        Dictionary<IDSignature, TreeEntity> all;

        TreeEntity[] temArray;

        public Dictionary<Vector2Int, TreeEntity> posDict;


        public TreeRepository() {
            all = new Dictionary<IDSignature, TreeEntity>();
            temArray = new TreeEntity[100];
            posDict = new Dictionary<Vector2Int, TreeEntity>();
        }

        public void Add(TreeEntity entity) {
            all.Add(entity.idSig, entity);
        }

        public void AddPos(Vector2Int pos, TreeEntity entity) {
            posDict.Add(pos, entity);
        }


        public void Remove(TreeEntity entity) {
            all.Remove(entity.idSig);
        }

        public void RemovePos(Vector2Int pos) {
            posDict.Remove(pos);
        }

        public int TakeAll(out TreeEntity[] array) {
            if (all.Count > temArray.Length) {
                temArray = new TreeEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);
            array = temArray;

            return all.Count;
        }
        public bool TryGet(IDSignature id, out TreeEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public bool IsPosHas(Vector2Int pos) {
            return posDict.ContainsKey(pos);
        }

        public TreeEntity FindByPos(Vector2Int pos) {
            if (posDict.TryGetValue(pos, out TreeEntity entity)) {
                return entity;
            }
            return null;
        }

        public void Clear() {
            all.Clear();
        }
    }
}