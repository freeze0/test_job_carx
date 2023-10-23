using System;
using UnityEngine;

namespace MyGolf 
{ 
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private GameObject mainCamera;
        [SerializeField] private GameObject plowController;
        [SerializeField] private GameObject plow;
        public int hitCount = 100;
        public int highScore;

        private void OnEnable()
        {
            GameEvents.onPlowHit += OnPlowHit;
        }

        private void OnDisable()
        {
            GameEvents.onPlowHit -= OnPlowHit;
        }

        private void OnPlowHit()
        {
            hitCount ++;
            highScore = Mathf.Min(highScore, hitCount);
        }
        
    }
}