using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Itorum
{
    public class HitTrackingSystem : MonoBehaviour
    {
        [Inject]
        private UIViewComponent uiView;

        [Inject]
        private RuntimeData runtimeData;

        private void Start()
        {
            runtimeData.NextStepRequest.AddListener(NextStepRequestAction);

            uiView.PlayerViewBtn.onClick.AddListener(() => ViewBtnClickAction(CamViews.Player));
            uiView.RocketViewBtn.onClick.AddListener(() => ViewBtnClickAction(CamViews.Rocket));
            uiView.RemoteViewBtn.onClick.AddListener(() => ViewBtnClickAction(CamViews.Remote));

            runtimeData.OnRocketHitAirplane.AddListener(RocketHitAirplaneAction);
        }

        private void Update()
        {
            if(runtimeData.CurrentStep == ScenarioStep.HitTracking)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                    ViewBtnClickAction(CamViews.Player);

                if (Input.GetKeyDown(KeyCode.Alpha2))
                    ViewBtnClickAction(CamViews.Rocket);

                if (Input.GetKeyDown(KeyCode.Alpha3))
                    ViewBtnClickAction(CamViews.Remote);
            }
        }

        private void NextStepRequestAction()
        {
            if (runtimeData.CurrentStep == ScenarioStep.HitTracking)
            {
                InitStep();
            }
        }

        private void InitStep()
        {
            // Включить кнопки выбора режима камеры
            uiView.ViewBtnsContainer.gameObject.SetActive(true);

            ResetViewBtns();

            SetBtnHighlightActive(GetViewBtn(CamViews.Player), true);
        }

        private void StepCompleteAction()
        {
            // Выключить кнопки выбора режима камеры
            uiView.ViewBtnsContainer.gameObject.SetActive(false);

            ResetViewBtns();

            runtimeData.OnStepComplete?.Invoke();
        }

        private void ViewBtnClickAction(CamViews view)
        {
            if (runtimeData.CurrentStep != ScenarioStep.HitTracking)
            {
                return;
            }

            ResetViewBtns();

            // Выделить нажатую кнопку
            SetBtnHighlightActive(GetViewBtn(view), true);

            runtimeData.CurrentCamView = view;

            runtimeData.OnSetCamView?.Invoke();

            // Сообщить о смене режима
            switch (view)
            {
                case CamViews.Player:
                    runtimeData.OnSetPlayerCamView?.Invoke();
                    break;
                case CamViews.Rocket:
                    runtimeData.OnSetRocketCamView?.Invoke();
                    break;
                case CamViews.Remote:
                    runtimeData.OnSetRemoteCamView?.Invoke();
                    break;
            }
        }

        private void ResetViewBtns()
        {
            // Сбросить выделение для всех кнопок
            SetBtnHighlightActive(uiView.PlayerViewBtn, false);
            SetBtnHighlightActive(uiView.RocketViewBtn, false);
            SetBtnHighlightActive(uiView.RemoteViewBtn, false);
        }

        private Button GetViewBtn(CamViews view)
        {
            switch (view)
            {
                case CamViews.Player:
                    return uiView.PlayerViewBtn;
                case CamViews.Rocket:
                    return uiView.RocketViewBtn;
                case CamViews.Remote:
                    return uiView.RemoteViewBtn;
                default:
                    return null;
            }
        }

        private void SetBtnHighlightActive(Button btn, bool value)
        {
            btn.GetComponent<Image>().color = value == true? uiView.ActiveBtnColor: uiView.InactiveBtnColor;
        }

        private void RocketHitAirplaneAction()
        {
            if (runtimeData.CurrentStep != ScenarioStep.HitTracking)
            {
                return;
            }

            StepCompleteAction();
        }
    }
}