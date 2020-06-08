using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

namespace Itorum
{
    public class CheckVisibleSystem : MonoBehaviour
    {
        private VisibleComponent visibleComponent;

        private List<Renderer> renderers = new List<Renderer>();

        private void Awake()
        {
            visibleComponent = GetComponent<VisibleComponent>();

            renderers = GetComponentsInChildren<Renderer>().ToList();
        }

        private void Update()
        {
            visibleComponent.IsVisible = renderers.Any(r => r.isVisible);
        }
    }
}