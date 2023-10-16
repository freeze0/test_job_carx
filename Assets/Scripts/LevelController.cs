using System;
using UnityEngine;

namespace MyGolf 
{ 
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private SpawnStone spawnStone;
        [SerializeField] private Camera mainCamera;
        public int hitCount = 0;
        public int highScore;

        public void Start()
        {
            spawnStone.Spawn();
        }

        private void OnEnable()
        {
            GameEvents.onPlowHit += OnPlowHit;
            GameEvents.onPlowHit += CameraFollowStone;
        }

        private void OnDisable()
        {
            GameEvents.onPlowHit -= OnPlowHit;
            GameEvents.onPlowHit -= CameraFollowStone;
        }

        private void OnPlowHit()
        {
            hitCount ++;
            highScore = Mathf.Min(highScore, hitCount);
            
        }

        private void CameraFollowStone()
        {
            
        }
        
    }
}