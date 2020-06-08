using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Itorum
{
    public class RestartSystem : MonoBehaviour
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
            uiView.RestartBtn.onClick.AddListener(RestartBtnClickAction);
        }

        private void RestartBtnClickAction()
        {
            SceneManager.LoadScene(0);
        }
    }
}