using System;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace MyGolf
{
    public class TouchControllerState : GameState
    {
        [SerializeField] private PlowController plowController;
        [SerializeField] private GameObject plow;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            plowController.enabled = true;
            plow.SetActive(true);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            plowController.enabled = false;
            if (plow)
            {
                plow.SetActive(false);
            }
        }
        
    }
}
