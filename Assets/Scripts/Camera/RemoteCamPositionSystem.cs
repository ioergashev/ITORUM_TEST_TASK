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
        private Player player;
        private DistanceComponent distanceComponent;
        private bool needReinstal = true;

        private void Awake()
        {
            runtimeData = FindObjectOfType<RuntimeData>();
            player = FindObjectOfType<Player>();
            distanceComponent = GetComponent<DistanceComponent>();
        }

        private void Start()
        {
            runtimeData.OnSetRemoteCamView.AddListener(SetRemoteCamViewAction);
        }

        private void Update()
        {
            // После смены режима, необходима перенастройка камеры
            if (runtimeData.CurrentCamView != CamViews.Remote)
            {
                needReinstal = true;
            }
        }

        private void SetRemoteCamViewAction()
        {
            if(!needReinstal)
            {
                return;
            }

            needReinstal = false;

            Vector3 a = Rocket != null? Rocket.forward: (Airplane.position - Player.position).normalized;
            Vector3 b = Airplane.forward;

            Plane plane = new Plane(a, b, Vector3.zero);

            Vector3 c = Rocket != null ? Rocket.position : Player.position;
            Vector3 d = Airplane.position;

            Vector3 target = Vector3.Lerp(c, d, 0.5f);

            transform.position = target + plane.normal * distanceComponent.Distance;

            transform.LookAt(target);
        }

        private Transform Airplane
        {
            get
            {
                return runtimeData.CurrentAirplane?.transform;
            }
        }

        private Transform Rocket
        {
            get
            {
                return runtimeData.CurrentRocket?.transform;
            }
        }

        private Transform Player
        {
            get
            {
                return player?.transform;
            }
        }
    }
}