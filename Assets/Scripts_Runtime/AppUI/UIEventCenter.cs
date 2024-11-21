using System;
using System.Collections.Generic;

using UnityEngine;

namespace TD {

    public class UIEventCenter {

        public Action OnLoginClickHandle;

        public void OnLoginClick() {
            if (OnLoginClickHandle != null) {
                OnLoginClickHandle.Invoke();
            }
        }

        public Action<int> OnMainfastClickHandle;
        public void OnMainfastClickElement(int typeID) {
            if (OnMainfastClickHandle != null) {
                OnMainfastClickHandle.Invoke(typeID);
            }
        }

        public Action OnRestartFailClickHandle;
        public void OnRestartClick() {
            if (OnRestartFailClickHandle != null) {
                OnRestartFailClickHandle.Invoke();
            }
        }

        public Action OnNextClickHandle;
        public void OnNextClick() {
            if (OnNextClickHandle != null) {
                OnNextClickHandle.Invoke();
            }
        }

        public Action OnRestartVictoryClickHandle;

        public void OnRestartVictoryClick() {
            if (OnRestartVictoryClickHandle != null) {
                OnRestartVictoryClickHandle.Invoke();
            }
        }

        public Action<int> OnStageElementBtnClickHandle;
        public void OnStageElementBtnClick(int stageID) {
            if (OnStageElementBtnClickHandle != null) {
                OnStageElementBtnClickHandle.Invoke(stageID);
            }
        }

        public Action OnRemoveClickTowerHandle;
        public void OnRemoveBtnClickTower() {
            if (OnRemoveClickTowerHandle != null) {
                OnRemoveClickTowerHandle.Invoke();
            }
        }

        public Action OnUpgradeClickTowerHandle;
        public void OnUpgradeBtnClickTower() {
            if (OnUpgradeClickTowerHandle != null) {
                OnUpgradeClickTowerHandle.Invoke();
            }
        }
    }
}