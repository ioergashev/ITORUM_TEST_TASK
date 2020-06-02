using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Itorum
{
    public class RemoteCamPositionSystem : MonoBehaviour
    {
        private RuntimeData runtimeData;
        private Camera camera;
        private DistanceComponent distanceComponent;

        private void Awake()
        {
            runtimeData = FindObjectOfType<RuntimeData>();
            camera = GetComponent<Camera>();
            distanceComponent = GetComponent<DistanceComponent>();
        }

        private void Start()
        {
            runtimeData.OnSetRemoteCamView.AddListener(SetRemoteCamViewAction);
        }

        private void SetRemoteCamViewAction()
        {
            Vector3 rocketSpeed = runtimeData.CurrentRocket.GetComponent<Rigidbody>().velocity;
            Vector3 airplaneSpeed = runtimeData.CurrentAirplane.GetComponent<Rigidbody>().velocity;

            Plane plane = new Plane(rocketSpeed, airplaneSpeed, Vector3.zero);

            Vector3 target = Vector3.Lerp(
                runtimeData.CurrentRocket.transform.position,
                runtimeData.CurrentAirplane.transform.position, 0.5f);

            transform.position = target + plane.normal * distanceComponent.Distance;

            transform.LookAt(target);
        }
    }
}