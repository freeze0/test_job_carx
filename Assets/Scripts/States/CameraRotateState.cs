using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace MyGolf
{
    public class CameraRotateState : GameState
    {
        [SerializeField] private CameraRotate camRot;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            camRot.enabled = true;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (camRot)
            {
                camRot.enabled = false;
            }
        }
        
        
    }
}