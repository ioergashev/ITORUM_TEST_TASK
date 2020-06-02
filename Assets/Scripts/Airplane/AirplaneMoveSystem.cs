using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itorum
{
    public class AirplaneMoveSystem : MonoBehaviour
    {
        private SpeedComponent speedComponent;
        private Airplane airplane;
        private Rigidbody rigidbody;

        private void Awake()
        {
            speedComponent = GetComponent<SpeedComponent>();
            airplane = GetComponent<Airplane>();
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            // Повернуть в случайном направлении
            float yRot = Random.Range(0, 360);
            airplane.transform.eulerAngles = new Vector3(0, yRot, 0);

            // Установить случайную скорость
            float speed = Random.Range(speedComponent.MinStartSpeed, speedComponent.MaxStartSpeed);
            rigidbody.velocity = airplane.transform.forward * speed;
        }
    }
}