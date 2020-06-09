using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;
using Zenject;

namespace Itorum
{
    public class ScenarioSystem : MonoBehaviour
    {
        [Inject]
        private RuntimeData runtimeData;

        private const float skipStepDelay = 0.5f;

        private bool isNextStep = false;

        protected readonly List<ScenarioStep> steps = new List<ScenarioStep>();
        protected int nextStepIndex = 0;

        protected virtual void Awake()
        {
            isNextStep = false;
            nextStepIndex = 0;

            StartCoroutine(PlayingScenatioRoutine());

            InitSteps();
        }

        protected void InitSteps()
        {
            steps.Add(ScenarioStep.WaitForRocketPrepare);
            steps.Add(ScenarioStep.WaitForRocketFire);
            steps.Add(ScenarioStep.HitTracking);
            steps.Add(ScenarioStep.HitSuccess);
        }

        protected virtual void Start()
        {
            NextStep();

            runtimeData.OnStepComplete.AddListener(StepCompleteAction);
        }

        private void StepCompleteAction()
        {
            NextStep();
        }

        private IEnumerator PlayingScenatioRoutine()
        {
            var wait = new WaitUntil(() => isNextStep);

            while (true)
            {
                yield return wait;
                if (nextStepIndex < steps.Count)
                {
                    runtimeData.CurrentStep = steps[nextStepIndex];

                    runtimeData.NextStepRequest?.Invoke();

                    nextStepIndex++;
                }

                isNextStep = false;
            }
        }

        protected void NextStep(float delay = 0)
        {
            void action()
            {
                isNextStep = true;
            }

            if (delay != 0)
            {
                DelayedLaunch(delay, action);
            }
            else
            {
                action();
            }
        }

        protected void Skip()
        {
            NextStep(skipStepDelay);
        }

        protected void DelayedLaunch(float delay, Action action)
        {
            StartCoroutine(DelayedLaunchCoroutine(action, delay));
        }

        protected IEnumerator DelayedLaunchCoroutine(Action action, float delay)
        {
            yield return new WaitForSeconds(delay);

            action.Invoke();
        }
    }
}