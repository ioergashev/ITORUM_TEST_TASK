using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Itorum
{
    public class VisibleComponent : MonoBehaviour
    {
        [HideInInspector]
        public bool IsVisible = false;

        [HideInInspector]
        public UnityEvent OnVisibleBegin = new UnityEvent();

        [HideInInspector]
        public UnityEvent OnVisibleEnd = new UnityEvent();
    }
}