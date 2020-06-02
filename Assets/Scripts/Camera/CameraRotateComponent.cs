using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itorum
{
    public class CameraRotateComponent : MonoBehaviour
    {
        public float MinXRotLimit = -45;
        public float MaxXRotLimit = 45;

        public float ScrollSpeed = 1;

        public bool InvertVert = false;
        public bool InvertHor = false;
    }
}