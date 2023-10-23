using System;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace MyGolf
{
    public class TouchControllerState : GameState
    {
        [SerializeField] private PlowController plowController;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            plowController.enabled = true;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            plowController.enabled = false;
        }
        
    }
}
