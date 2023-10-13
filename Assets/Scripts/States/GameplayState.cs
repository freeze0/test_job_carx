using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Golf
{
    public class GameplayState : GameState
    {
        public LevelController levelController;
        public PlayerController playerController;

        protected override void OnEnable()
        {
            base.OnEnable();
            levelController.enabled = true;
            playerController.enabled = true;

            //GameEvents.onCollisionStone += onGameOver;

        }

        protected override void OnDisable()
        {
            base.OnDisable();
            levelController.enabled = false;
            playerController.enabled = false;

            //GameEvents.onCollisionStone -= onGameOver;

        }

    }
}
