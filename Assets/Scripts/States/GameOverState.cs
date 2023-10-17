using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGolf
{
    public class GameOverState : GameState
    {
        [SerializeField] private GameplayState gameplayState;

        
        protected override void OnEnable()
        {
            base.OnEnable();
        }
        
        public void RestartGame()
        {
            Exit();
            gameplayState.Enter();
        }
    }
}
