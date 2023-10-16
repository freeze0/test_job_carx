using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGolf
{
    public class PlowController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Stone"))
            {
                Debug.Log("i Hit the stone");
                GameEvents.PlowHit();
            }
        }
    }
}
