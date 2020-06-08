using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Itorum
{
    public class CamViewController : MonoBehaviour
    {
        public CamViews camView = CamViews.None;

        private RuntimeData runtimeData;
        private Camera camera;

        private void Awake()
        {
            runtimeData = FindObjectOfType<RuntimeData>();
            camera = GetComponent<Camera>();
        }

        private void Start()
        {
            runtimeData.OnSetCamView.AddListener(SetCamViewAction);
        }

        private void SetCamViewAction()
        {
            SetCamActive(runtimeData.CurrentCamView == camView);
        }

        private void SetCamActive(bool value)
        {
            camera.enabled = value;
        }
    }
}