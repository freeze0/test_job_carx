using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace MyGolf
{
    
    public class GameplayState : GameState
    {
        [SerializeField] private LevelController levelController;
        [SerializeField] private TouchController touchController;
        [SerializeField] private GameOverState gameOverState;
        public TMP_Text scoreText;
        protected override void OnEnable()
        {
            base.OnEnable();
            touchController.enabled = true;
            levelController.enabled = true;
            
            GameEvents.onPlowHit += OnPlowHit;
            
        }

        private void OnGameEnded()
        {
            Exit();
            gameOverState.Enter();
        }

        private void OnPlowHit()
        {
            scoreText.text = $"score : {levelController.hitCount}";
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            touchController.enabled = false;
            levelController.enabled = false;
            
            GameEvents.onPlowHit -= OnPlowHit;
        }
    }
}
