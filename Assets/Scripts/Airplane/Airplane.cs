using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itorum
{
    public class Airplane : MonoBehaviour
    {
        public VisibleComponent VisibleComponent;

        private void Awake()
        {
            VisibleComponent = GetComponent<VisibleComponent>();
        }
    }
}