using System;
using UnityEngine;

namespace MyGolf 
{ 
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private GameObject mainCamera;
        [SerializeField] private GameObject plowController;
        public int hitCount = 0;
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
            mainCamera.GetComponent<FollowStone>().enabled = true;
            plowController.SetActive(false);
        }

        private void OnStoneStop()
        {
            mainCamera.GetComponent<FollowStone>().enabled = false;
            plowController.SetActive(true);
        }
        
        
    }
}