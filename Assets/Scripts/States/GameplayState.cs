using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;


namespace MyGolf
{
    
    public class GameplayState : GameState
    {
        [SerializeField] private SceneController sc;
        [SerializeField] private LevelController levelController;
        [SerializeField] private GameOverState gameOverState;
        [SerializeField] private List<GameObject> States;
        private GameObject current;
        private GameObject prev;
        private int currentState = 0;
        public TMP_Text scoreText;
        protected override void OnEnable()
        {
            base.OnEnable();
            States[0].SetActive(true);
            levelController.enabled = true;
            GameEvents.onPlowHit += OnPlowHit;
            GameEvents.onCollisionFinish += OnGameEnded;
            GameEvents.onStoneStop += OnStoneStop;
        }

        private void OnGameEnded()
        {
            Exit();
            gameOverState.Enter();
        }

        private void OnPlowHit()
        {
            StateChanger();
            scoreText.text = $"score : {levelController.hitCount}";
        }

        private void OnStoneStop()
        {
            StateChanger();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (levelController)
            {
                levelController.enabled = false;
            }   
            GameEvents.onPlowHit -= OnPlowHit;
            GameEvents.onCollisionFinish -= OnGameEnded;
            GameEvents.onStoneStop -= OnStoneStop;
        }

        private void StateChanger()
        {
            for (int i = 0; i < States.Count; i++)
            {
                if (States[i].activeSelf)
                {
                    Debug.Log($"Active state: {States[i]}");
                    if (i == States.Count - 1)
                    {
                        States[0].SetActive(true);
                    }
                    else
                    {
                        States[i + 1].SetActive(true);
                    }
                    States[i].SetActive(false);
                    return;
                }
            }
        }

        public void Cancel()
        {
            States[0].SetActive(true);
            States[1].SetActive(false);
        }

        public void Shoot()
        {
            StateChanger();
        }
        
        public void Restart()
        {
            sc.ReloadScene();
            Exit();
        }
    }
}
