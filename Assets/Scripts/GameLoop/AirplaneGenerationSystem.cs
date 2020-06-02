using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Itorum
{
    public class AirplaneGenerationSystem : MonoBehaviour
    {
        [Inject(Id = "airplane_origin")]
        private StartOrientationComponent airplaneStartOrient;

        private RuntimeData runtimeData;

        private void Awake()
        {
            runtimeData = FindObjectOfType<RuntimeData>();
        }

        private void Start()
        {
            GenerateAirplane();
        }

        private void GenerateAirplane()
        {
            Airplane airplane;

            if (airplaneStartOrient.isParent)
            {
                airplane = Instantiate(GameSettings.Instance.AirplanePrefab, airplaneStartOrient.StartOrient).GetComponent<Airplane>();
            }
            else
            {
                airplane = Instantiate(GameSettings.Instance.AirplanePrefab, airplaneStartOrient.StartOrient.position, airplaneStartOrient.StartOrient.rotation).GetComponent<Airplane>();
            }

            runtimeData.CurrentAirplane = airplane;
        }
    }
}