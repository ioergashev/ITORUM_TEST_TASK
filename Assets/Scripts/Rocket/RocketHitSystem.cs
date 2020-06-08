using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Itorum
{
    public class RocketHitSystem : MonoBehaviour
    {
        private RuntimeData runtimeData;
        private ExplosionComponent explosionComponent;

        private void Awake()
        {
            runtimeData = FindObjectOfType<RuntimeData>();
            explosionComponent = GetComponent<ExplosionComponent>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            var explodedComponent = collision.transform.GetComponent<ExplodedComponent>();

            // Если имеестя компонент
            if (explodedComponent != null)
            {            
                explodedComponent.PiecesContainer.gameObject.SetActive(true);

                explodedComponent.PiecesContainer.SetParent(null);

                collision.gameObject.SetActive(false);

                var pieces = explodedComponent.PiecesContainer.GetComponentsInChildren<Rigidbody>();

                foreach(var piece in pieces)
                {
                    piece.AddExplosionForce(explosionComponent.ExplisionForce, transform.position, explosionComponent.ExplisionRadius, explosionComponent.UpwardsModifier);
                }
            }
            else
            {
                collision.rigidbody.AddExplosionForce(explosionComponent.ExplisionForce, transform.position, explosionComponent.ExplisionRadius, explosionComponent.UpwardsModifier);
            }

            runtimeData.OnRocketHitAirplane?.Invoke();

            gameObject.SetActive(false);
        }
    }
}