using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


namespace MyGolf
{
    
    public class GameplayState : GameState
    {
        [SerializeField] private SceneController sc;
        [SerializeField] private LevelController levelController;
        [FormerlySerializedAs("touchPlowController")] [SerializeField] private TouchControllerState touchControllerState;
        [SerializeField] private GameOverState gameOverState;
        [FormerlySerializedAs("camRotate")] [SerializeField] private CameraRotateState camRotateState;
        [SerializeField] private FollowStone camFollow;
        [SerializeField] private Button shootButton;
        [SerializeField] private Button cancelButton;
        public TMP_Text scoreText;
        protected override void OnEnable()
        {
            base.OnEnable();
            camFollow.enabled = false;
            camRotateState.enabled = true;
            touchControllerState.enabled = false;
            levelController.enabled = true;
            cancelButton.gameObject.SetActive(false);
            shootButton.gameObject.SetActive(true);
            touchControllerState.Plow.SetActive(false);
            GameEvents.onPlowHit += OnPlowHit;
            GameEvents.onCollisionFinish += OnGameEnded;
            GameEvents.onStoneStop += OnStoneStopUI;
        }

        private void OnGameEnded()
        {
            Exit();
            gameOverState.Enter();
        }

        private void OnPlowHit()
        {
            camFollow.enabled = true;
            StateChanger();
            shootButton.gameObject.SetActive(false);
            scoreText.text = $"score : {levelController.hitCount}";
        }

        private void OnStoneStopUI()
        {
            camFollow.enabled = false;
            if (camRotateState.enabled == true)
            {
                shootButton.gameObject.SetActive(true);
            }
            else
            {
                shootButton.gameObject.SetActive(false);
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (touchControllerState)
            {
                touchControllerState.enabled = false;
            }
            if ( levelController)
            {
                levelController.enabled = false;
            }   
            GameEvents.onPlowHit -= OnPlowHit;
            GameEvents.onCollisionFinish -= OnGameEnded;
            GameEvents.onStoneStop -= OnStoneStopUI;
        }
        
        public void Restart()
        {
            sc.ReloadScene();
            Exit();
        }

        public void StateChanger()
        {
            camRotateState.enabled = !camRotateState.enabled;
            touchControllerState.enabled = !touchControllerState.enabled;
            shootButton.gameObject.SetActive(camRotateState.enabled); 
            cancelButton.gameObject.SetActive(touchControllerState.enabled);
            if (camRotateState.enabled)
            {
                touchControllerState.Plow.SetActive(false);
            }
            else
            {
                touchControllerState.Plow.SetActive(true);
            }
        }
        
    }
}
