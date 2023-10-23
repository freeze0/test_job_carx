using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGolf{
    public class FollowStoneState : GameState
    {
        [SerializeField] private FollowStone camFollow;
        protected override void OnEnable()
        {
            base.OnEnable();
            camFollow.enabled = true;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            camFollow.enabled = false;
        }
        
    }
}