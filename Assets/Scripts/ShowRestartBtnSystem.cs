using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Itorum
{
    public class ShowRestartBtnSystem : MonoBehaviour
    {
        private RuntimeData runtimeData;
        private UIViewComponent uiView;

        private void Awake()
        {
            uiView = FindObjectOfType<UIViewComponent>();
            runtimeData = FindObjectOfType<RuntimeData>();
        }

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