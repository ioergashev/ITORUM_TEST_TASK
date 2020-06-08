//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Zenject;

//namespace Itorum
//{
//    public abstract class ScenarioBase : MonoBehaviour
//    {
//        private const float skipStepDelay = 0.5f;

//        private bool isNextStep = false;

//        protected readonly List<Action> steps = new List<Action>();
//        protected int nextStepIndex = 0;

//        protected virtual void Awake()
//        {
//            isNextStep = false;
//            nextStepIndex = 0;

//            StartCoroutine(PlayingScenatioRoutine());

//            InitSteps();
//        }

//        protected abstract void InitSteps();

//        protected virtual void Start()
//        {
//            NextStep();
//        }


//        private IEnumerator PlayingScenatioRoutine()
//        {
//            var wait = new WaitUntil(() => isNextStep);

//            while (true)
//            {
//                yield return wait;
//                if (nextStepIndex < steps.Count)
//                {
//                    Debug.Log("Exercise Step Started: " + steps[nextStepIndex].Method.ToString());

//                    steps[nextStepIndex]?.Invoke();

//                    nextStepIndex++;
//                }

//                isNextStep = false;
//            }
//        }

//        protected void NextStep(float delay = 0)
//        {
//            void action()
//            {
//                isNextStep = true;
//            }

//            if (delay != 0)
//            {
//                DelayedLaunch(delay, action);
//            }
//            else
//            {
//                action();
//            }
//        }

//        protected void Skip()
//        {
//            NextStep(skipStepDelay);
//        }

//        protected void DelayedLaunch(float delay, Action action)
//        {
//            StartCoroutine(DelayedLaunchCoroutine(action, delay));
//        }

//        protected IEnumerator DelayedLaunchCoroutine(Action action, float delay)
//        {
//            yield return new WaitForSeconds(delay);

//            action.Invoke();
//        }
//    }
//}