using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Serialization;

namespace Golf 
{ 

    public class LevelController : MonoBehaviour
    {
        public StoneSpawner spawner;
        
        private List<GameObject> m_stones = new List<GameObject>(16);
        
        private float m_lastspawnedTime = 0;

        public float delayMax = 2f;
        public float delayMin = 0.5f;
        public float delayStep = 0.1f;
        public int highScore = 0;
        private float m_delay = 0.5f;
        [FormerlySerializedAs("count")] public int score = 0;
        


        private void Start()
        {
            m_lastspawnedTime = Time.time;
            RefreshDelay();
        }

        private void OnEnable()
        {
            score = 0;
            GameEvents.onStickHit += HitCounts;
        }

        private void OnDisable()
        {
            
            GameEvents.onStickHit -= HitCounts;
        }

        private void Update()
        {
            if (Time.time >= m_lastspawnedTime + m_delay)
            {
                var stone = spawner.Spawn();
                m_stones.Add(stone);
                m_lastspawnedTime = Time.time;
                RefreshDelay(); 
            }
        }

        public void RefreshDelay()
        {
            m_delay = UnityEngine.Random.Range(delayMax, delayMin);
            delayMax = Mathf.Max(delayMax, delayMin - delayStep);
        }

        private void HitCounts()
        {
            score += 1;
            highScore = Mathf.Max(highScore, score);
            Debug.Log("Hit count = " + score);
            Debug.Log("HighScore = " + highScore);

        }

        public void ClearStones()
        {
            foreach (var stone in m_stones)
            {
                Destroy(stone);
            }

            m_stones.Clear();
        }
        
    }
}