using System.Collections;
using System.Collections.Generic;
using MyGolf;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyGolf
{
    public class MainMenuState : GameState
    {
        [SerializeField] private LevelController levelController;
        [SerializeField] private GameplayState gameplayState;
        [SerializeField] private TMP_Text scoreText;

        public void PlayGame()
        {
            Exit();
            gameplayState.Enter();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            scoreText.text = $"HighScore : {levelController.highScore}";
        }
    }
}
