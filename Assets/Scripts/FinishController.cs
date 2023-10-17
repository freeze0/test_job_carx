using System;
using System.Collections;
using System.Collections.Generic;
using MyGolf;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Stone"))
        {
            GameEvents.OnCollisionFinish();
        }
    }
}
