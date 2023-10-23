using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGolf
{
    public class Plow : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Stone"))
            {
                GameEvents.PlowHit();
            }
        }
    }
}
