using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Zenject;

namespace Itorum
{
    public class ShowRestartBtnSystem : MonoBehaviour
    {
        [Inject]
        private RuntimeData runtimeData;
        [Inject]
        private UIViewComponent uiView;

        private void Start()
        {
            runtimeData.OnRocketHitAirplane.AddListener(RocketHitAirplaneAction);
        }

        private void RocketHitAirplaneAction()
        {
            uiView.RestartBtn.gameObject.SetActive(true);
        }
    }
}