//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Zenject;

//namespace Itorum
//{
//    public class KeyBoardControlSystem : MonoBehaviour
//    {
//        private UIViewComponent uiView;

//        [Inject(Id = "rocket_origin")]
//        private StartOrientationComponent rocketStartOrient;

//        private RuntimeData runtimeData;

//        private void Awake()
//        {
//            uiView = FindObjectOfType<UIViewComponent>();
//            runtimeData = FindObjectOfType<RuntimeData>();
//        }

//        private void Start()
//        {
//            uiView.PrepareBtn.onClick.AddListener(PrepareBtnClickAction);
//        }

//        private void Update()
//        {
//            switch(runtimeData.CurrentScenarioStep)
//            {
//                case ScenarioStep.WaitForRocketPrepare:
                    
//                    break;
//            }
//        }

//        private void PrepareBtnClickAction()
//        {
//            Rocket rocket;

//            if (rocketStartOrient.isParent)
//            {
//                rocket = Instantiate(GameSettings.Instance.RocketPrefab, rocketStartOrient.StartOrient).GetComponent<Rocket>();
//            }
//            else
//            {
//                rocket = Instantiate(GameSettings.Instance.RocketPrefab, rocketStartOrient.StartOrient.position, rocketStartOrient.StartOrient.rotation).GetComponent<Rocket>();
//            }

//            runtimeData.CurrentRocket = rocket;

//            uiView.PrepareBtn.gameObject.SetActive(false);
//        }
//    }
//}