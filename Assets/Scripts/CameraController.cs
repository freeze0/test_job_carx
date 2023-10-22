using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MyGolf
{
    public class CameraController : MonoBehaviour
    {
        [FormerlySerializedAs("camRotate")] [SerializeField] private CameraRotateState camRotateState;
        [SerializeField] private FollowStone camFollow;

        private void OnEnable()
        {
            GameEvents.onPlowHit += ChangeCamScript;
            GameEvents.onStoneStop += ChangeCamScript;
        }

        private void OnDisable()
        {
            GameEvents.onPlowHit -= ChangeCamScript;
            GameEvents.onStoneStop -= ChangeCamScript;
        }

        private void ChangeCamScript()
        {
            if (camRotateState.enabled)
            {
                camRotateState.enabled = false;
                camFollow.enabled = true;
            }
            else
            {
                camRotateState.enabled = true;
                camFollow.enabled = false;
            }
        }
    }
}
