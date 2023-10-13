using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

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
        public int count = 0;
        


        private void Start()
        {
            //StartCoroutine(SpawnStoneProc());
            m_lastspawnedTime = Time.time;
            RefreshDelay();
        }

        private void OnEnable()
        {
            GameEvents.onCollisionStone += GameOver;
            GameEvents.onStickHit += HitCounts;
        }

        private void OnDisable()
        {
            GameEvents.onCollisionStone -= GameOver;
            GameEvents.onStickHit -= HitCounts;
        }

        private void GameOver()
        {
            Debug.Log("Game over");
            enabled = false;

        }

        private void Update()
        {
            if (Time.time >= m_lastspawnedTime + m_delay) { 
                spawner.Spawn();
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
            count += 1;
            highScore = highScore > count ? highScore : count;
            Debug.Log("Hit count = " + count);
            Debug.Log("HighScore = " + highScore);

        }

        private void ClearStones()
        {
            foreach (GameObject stone in m_stones)
            {
                Destroy(stone);
            }
        }

        /*private IEnumerator SpawnStoneProc()
        {
            do
            {
                yield return new WaitForSeconds(delay); // yield запоминает предыдущие состояния
                spawner.Spawn();
            }
            while (!isGameOver);
        }*/
    }
}