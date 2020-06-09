using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;

namespace Itorum
{
    public class SignalOnTargetVisibleSystem : MonoBehaviour
    {
        [Inject]
        private RuntimeData runtimeData;
        [Inject]
        private ManagerId managerId;

        [Inject(Id = "target_enter_sound")]
        private AudioSource sound;

        [Inject(Id = "target_enter_frame_image")]
        private Image image;

        private IEnumerator Start()
        {
            yield return new WaitUntil(() => runtimeData?.CurrentAirplane?.VisibleComponent != null);

            runtimeData.CurrentAirplane.VisibleComponent.OnVisibleBegin.AddListener(TargetVisibleBeginAction);
        }

        private void TargetVisibleBeginAction()
        {
            if (runtimeData.CurrentStep == ScenarioStep.WaitForRocketPrepare)
            {
                sound?.Play();

                var color = image.color;

                color.a = 1f;

                image.color = color;

                image?.DOFade(0, 2f);
            }
        }
    }
}