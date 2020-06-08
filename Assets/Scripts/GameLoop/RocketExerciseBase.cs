//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.UI;
//using Zenject;

//namespace Itorum
//{
//    public abstract class RocketExerciseBase : ScenarioBase
//    {
//        private void CkickBtn(Button btn, KeyCode btnKey, Action init = null, Action fallback = null)
//        {
//            // Настроить действие
//            void action()
//            {
//                btn.onClick.RemoveListener(action);

//                fallback?.Invoke();

//                NextStep();
//            }

//            // Ожидать выполнения действия
//            btn.onClick.AddListener(action);
//            AddKeyDownListener(action);
//        }



//        private void AddKeyDownListener(KeyCode key, UnityAction action)
//        {
//            StartCoroutine(WaitForKeyDown(key, action));
//        }

//        private IEnumerator WaitForKeyDown(KeyCode key, UnityAction action)
//        {
//            yield return new WaitUntil(() => Input.GetKeyDown(key));

//            action?.Invoke();
//        }
//    }
//}