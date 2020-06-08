using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Itorum
{
    public class ExplodeOnGroundController : MonoBehaviour
    {
        bool first = true;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "Ground" && first)
            {
                first = false;

                var explode = transform.Find("WFX_Nuke")?.GetComponent<ParticleSystem>();
                explode?.Play(true);
                explode?.transform.SetParent(null);
            }
        }
    }
}