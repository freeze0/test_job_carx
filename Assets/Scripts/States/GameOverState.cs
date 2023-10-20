using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGolf
{
   
    public class GameOverState : GameState
    {
        [SerializeField] private SceneController sc;
        
        protected override void OnEnable()
        {
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }

        public void LoadNextLevel()
        {
            sc.LoadNextScene();
            Exit();
        }
    }
}
