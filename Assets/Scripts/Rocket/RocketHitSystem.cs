using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itorum
{
    public class RocketHitSystem : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            collision.rigidbody.useGravity = true;

            Destroy(gameObject);
        }
    }
}