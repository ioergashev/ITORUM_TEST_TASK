using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Itorum
{
    public class HitSuccessSystem : MonoBehaviour
    {
        private UIViewComponent uiView;

        private RuntimeData runtimeData;

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
            // Переключится на отдаленную камеру
            runtimeData.CurrentCamView = CamViews.Remote;

            runtimeData.OnSetCamView?.Invoke();

            runtimeData.OnSetRemoteCamView?.Invoke();

            uiView.HitSuccessTxt.gameObject.SetActive(true);
            uiView.RestartBtn.gameObject.SetActive(true);
        }
    }
}