using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Itorum
{
    public class PrepareRocketSystem : MonoBehaviour
    {
        private UIViewComponent uiView;

        [Inject(Id = "rocket_origin")]
        private StartOrientationComponent rocketStartOrient;

        private RuntimeData runtimeData;

        private void Awake()
        {
            uiView = FindObjectOfType<UIViewComponent>();
            runtimeData = FindObjectOfType<RuntimeData>();
        }

        private void Start()
        {
            runtimeData.NextStepRequest.AddListener(NextStepRequestAction);

            uiView.PrepareBtn.onClick.AddListener(PrepareBtnClickAction);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                PrepareBtnClickAction();
        }

        private void NextStepRequestAction()
        {
            if(runtimeData.CurrentStep == ScenarioStep.WaitForRocketPrepare)
            {
                InitStep();
            }
        }

        private void InitStep()
        {
            uiView.PrepareBtn.gameObject.SetActive(true);
        }

        private void StepCompleteAction()
        {
            uiView.PrepareBtn.gameObject.SetActive(false);

            runtimeData.OnStepComplete?.Invoke();
        }

        private void PrepareBtnClickAction()
        {
            if (runtimeData.CurrentStep != ScenarioStep.WaitForRocketPrepare)
            {
                return;
            }

            // Если самолет вне зоны видимости
            if (!runtimeData.CurrentAirplane.GetComponent<VisibleComponent>().IsVisible)
            {
                // Показать ошибку
                runtimeData.ShowErrorMessageRequest?.Invoke();
                
                return;
            }

            Rocket rocket;

            // Показать ракету
            if (rocketStartOrient.isParent)
            {
                rocket = Instantiate(GameSettings.Instance.RocketPrefab, rocketStartOrient.StartOrient).GetComponent<Rocket>();
            }
            else
            {
                rocket = Instantiate(GameSettings.Instance.RocketPrefab, rocketStartOrient.StartOrient.position, rocketStartOrient.StartOrient.rotation).GetComponent<Rocket>();
            }

            runtimeData.CurrentRocket = rocket;

            StepCompleteAction();
        }
    }
}