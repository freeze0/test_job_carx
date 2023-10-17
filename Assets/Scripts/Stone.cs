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

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (rb.velocity.magnitude == 0.0f)
            {
                GameEvents.OnStoneStop();
            }
        }
    }
}
