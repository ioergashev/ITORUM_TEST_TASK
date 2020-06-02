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
            uiView.PrepareBtn.onClick.AddListener(PrepareBtnClickAction);
            uiView.FireBtn.onClick.AddListener(FireBtnClickAction);
        }

        private void PrepareBtnClickAction()
        {
            uiView.FireBtn.gameObject.SetActive(true);
        }

        private void FireBtnClickAction()
        {
            runtimeData.CurrentRocket.GetComponent<MoveComponent>().StartMoveRequest?.Invoke();

            uiView.FireBtn.gameObject.SetActive(false);
        }
    }
}