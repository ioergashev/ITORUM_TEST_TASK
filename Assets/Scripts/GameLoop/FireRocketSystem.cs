using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Itorum
{
    public class FireRocketSystem : MonoBehaviour
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

            uiView.FireBtn.onClick.AddListener(FireBtnClickAction);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                FireBtnClickAction();
        }

        private void NextStepRequestAction()
        {
            if (runtimeData.CurrentStep == ScenarioStep.WaitForRocketFire)
            {
                InitStep();
            }
        }

        private void InitStep()
        {
            uiView.FireBtn.gameObject.SetActive(true);
        }

        private void StepCompleteAction()
        {
            uiView.FireBtn.gameObject.SetActive(false);

            runtimeData.OnStepComplete?.Invoke();
        }

        private void FireBtnClickAction()
        {
            if (runtimeData.CurrentStep != ScenarioStep.WaitForRocketFire)
            {
                return;
            }

            runtimeData.CurrentRocket.GetComponent<MoveComponent>().StartMoveRequest?.Invoke();

            StepCompleteAction();
        }
    }
}