using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Golf
{
    public class GameplayState : GameState
    {
        public LevelController levelController;
        public TouchController plowController;
        public GameState gameOverState;
        public TMP_Text scoreText;

        protected override void OnEnable()
        {
            base.OnEnable();
            levelController.enabled = true;
            plowController.enabled = true;

            GameEvents.onCollisionStones += OnGameOver;
            GameEvents.onStickHit += OnStickHit;
            
            OnStickHit();

        }
        
        private void OnStickHit()
        {
            scoreText.text = $"score : {levelController.score}";
        }

        private void OnGameOver()
        {
            Exit();
            gameOverState.Enter();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            
            GameEvents.onCollisionStones -= OnGameOver;
            
            levelController.enabled = false;
            plowController.enabled = false;

        }
    }
}
