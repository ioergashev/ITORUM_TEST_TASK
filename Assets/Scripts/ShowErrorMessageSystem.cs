using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Zenject;

namespace Itorum
{
    public class ShowErrorMessageSystem : MonoBehaviour
    {
        [Inject]
        private RuntimeData runtimeData;
        [Inject]
        private UIViewComponent uiView;

        private void Start()
        {
            runtimeData.ShowErrorMessageRequest.AddListener(OnShowErrorMessageRequest);
        }

        private void OnShowErrorMessageRequest()
        {
            StartCoroutine(FadeAnimation());
        }

        private IEnumerator FadeAnimation()
        {
            uiView.ErrorMessageTxt.gameObject.SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                yield return FadeIteration();
            }

            uiView.ErrorMessageTxt.gameObject.SetActive(false);
        }

        private IEnumerator FadeIteration()
        {
            uiView.ErrorMessageTxt.DOFade(1, 0.5f);
            yield return new WaitForSeconds(0.5f);

            yield return new WaitForSeconds(0.5f);

            uiView.ErrorMessageTxt.DOFade(0, 0.5f);
            yield return new WaitForSeconds(0.5f);
        }
    }
}