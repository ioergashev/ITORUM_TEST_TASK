using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            runtimeData.NextStepRequest.AddListener(NextStepRequestAction);
        }

        private void NextStepRequestAction()
        {
            if (runtimeData.CurrentStep == ScenarioStep.HitSuccess)
            {
                InitStep();
            }
        }

        private void InitStep()
        {
            // Переключится на отдаленную камеру
            runtimeData.CurrentCamView = CamViews.Remote;

            runtimeData.OnSetCamView?.Invoke();

            runtimeData.OnSetRemoteCamView?.Invoke();

            uiView.HitSuccessTxt.gameObject.SetActive(true);
        }
    }
}