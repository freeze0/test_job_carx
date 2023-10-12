using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Golf
{
    public class Plow : MonoBehaviour
    {
        public UnityEvent<Collider> onCollision;
        public static System.Action onHit;
        
        private void OnCollisionEnter(Collision collision)
        {
            onCollision.Invoke(collision.collider);
            if (collision.collider.TryGetComponent(out Stone stone))
            {
                onHit?.Invoke();
            }
        }
    }
}