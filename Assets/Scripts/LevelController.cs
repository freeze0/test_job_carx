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
            GameEvents.onPlowHit += CameraFollowStone;
            GameEvents.onStoneStop += OnStoneStop;
        }

        private void OnDisable()
        {
            GameEvents.onPlowHit -= OnPlowHit;
            GameEvents.onPlowHit -= CameraFollowStone;
            GameEvents.onStoneStop -= OnStoneStop;
        }

        private void OnPlowHit()
        {
            hitCount ++;
            highScore = Mathf.Min(highScore, hitCount);
        }

        private void CameraFollowStone()
        {
            plowController.SetActive(false);
        }

        private void OnStoneStop()
        {
            plowController.SetActive(true);
        }
    }
}