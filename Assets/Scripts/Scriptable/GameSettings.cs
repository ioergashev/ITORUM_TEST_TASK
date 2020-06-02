using UnityEngine;
using System;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Itorum
{
    [Serializable]
    [CreateAssetMenu(fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        private static GameSettings _instance;

        public static GameSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<GameSettings>("Itorum/GameSettings");
                }

                return _instance;
            }
        }

        public GameObject RocketPrefab;
        public GameObject AirplanePrefab;
    }
}