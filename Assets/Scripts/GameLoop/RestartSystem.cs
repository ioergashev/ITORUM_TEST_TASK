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
        [Inject]
        private UIViewComponent uiView;

        [Inject]
        private RuntimeData runtimeData;

        private void Start()
        {
            uiView.RestartBtn.onClick.AddListener(RestartBtnClickAction);
        }

        private void RestartBtnClickAction()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}