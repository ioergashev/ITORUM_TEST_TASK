using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Itorum
{
    public class RocketMoveSystem : MonoBehaviour
    {
        private SpeedComponent speedComponent;
        private Rocket rocket;
        private Rigidbody rigidbody;
        private MoveComponent moveComponent;
        private RuntimeData runtimeData;

        private void Awake()
        {
            runtimeData = FindObjectOfType<RuntimeData>();
            speedComponent = GetComponent<SpeedComponent>();
            rocket = GetComponent<Rocket>();
            rigidbody = GetComponent<Rigidbody>();
            moveComponent = GetComponent<MoveComponent>();
        }

        private void Start()
        {
            moveComponent.StartMoveRequest.AddListener(StartMoveAction);
        }

        private void StartMoveAction()
        {
            moveComponent.IsMoving = true;

            rigidbody.isKinematic = false;

            transform.SetParent(null);
        }

        private void Update()
        {
            var airplane = runtimeData.CurrentAirplane;

            if (airplane != null && moveComponent.IsMoving)
            {
                transform.LookAt(airplane.transform);
                rigidbody.velocity = (airplane.transform.position - transform.position).normalized * speedComponent.Speed * Time.deltaTime;
            }
        }
    }
}