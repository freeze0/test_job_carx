using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


namespace MyGolf
{
    
    public class GameplayState : GameState
    {
        [SerializeField] private SceneController sc;
        [SerializeField] private LevelController levelController;
        [SerializeField] private TouchPlowController touchPlowController;
        [SerializeField] private GameOverState gameOverState;
        public TMP_Text scoreText;
        protected override void OnEnable()
        {
            base.OnEnable();
            touchPlowController.enabled = true;
            levelController.enabled = true;
            
            GameEvents.onPlowHit += OnPlowHit;
            GameEvents.onCollisionFinish += OnGameEnded;
            GameEvents.onPlowHit += touchPlowController.RestartPosition;
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
            if (touchPlowController)
            {
                touchPlowController.enabled = false;
            }
            levelController.enabled = false;
            
            GameEvents.onPlowHit -= OnPlowHit;
            GameEvents.onCollisionFinish -= OnGameEnded;
            GameEvents.onPlowHit -= touchPlowController.RestartPosition;
        }
        
        public void Restart()
        {
            sc.ReloadScene();
            Exit();
        }
    }
}
