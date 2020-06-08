using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Itorum
{
    public enum CamViews
    {
        None,
        Player,
        Rocket,
        Remote
    }

    public enum ScenarioStep
    {
        None,
        WaitForRocketPrepare,
        WaitForRocketFire,
        HitTracking,
        HitSuccess
    }

    public class RuntimeData : MonoBehaviour
    {
        [HideInInspector]
        public Rocket CurrentRocket;

        [HideInInspector]
        public Airplane CurrentAirplane;

        [HideInInspector]
        public CamViews CurrentCamView = CamViews.Player;

        [HideInInspector]
        public ScenarioStep CurrentStep = ScenarioStep.WaitForRocketPrepare;

        [HideInInspector]
        public UnityEvent OnSetCamView = new UnityEvent();
        [HideInInspector]
        public UnityEvent OnSetPlayerCamView = new UnityEvent();
        [HideInInspector]
        public UnityEvent OnSetRocketCamView = new UnityEvent();
        [HideInInspector]
        public UnityEvent OnSetRemoteCamView = new UnityEvent();

        [HideInInspector]
        public UnityEvent OnNextStep = new UnityEvent();

        [HideInInspector]
        public UnityEvent OnRocketHitAirplane = new UnityEvent();
    }
}