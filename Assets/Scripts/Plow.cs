using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Golf
{
    public class Plow : MonoBehaviour
    {
        public UnityEvent<Collider> onCollision;
        private void OnCollisionEnter(Collision collision)
        {
            onCollision.Invoke(collision.collider);
        }
    }
}