using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Itorum
{
    public class MoveComponent : MonoBehaviour
    {
        public UnityEvent StartMoveRequest = new UnityEvent();

        public bool IsMoving = false;
    }
}