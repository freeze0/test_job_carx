using System;
using System.Collections;
using System.Collections.Generic;
using MyGolf;
using UnityEngine;

namespace MyGolf
{
    public class Stone : MonoBehaviour
    {
        private Rigidbody rb;
        private bool isStopped = false;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (rb.velocity.magnitude != 0.0f)
            {
                isStopped = false;
            }
            else
            {
                if (!isStopped)
                {
                    isStopped = true;
                    GameEvents.OnStoneStop();
                    Debug.Log("Stone Stop");
                }
            }
        }
    }
}
