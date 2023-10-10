using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf 
{ 

    public class LevelController : MonoBehaviour
    {
        public StoneSpawner spawner;
        public bool isGameOver = false;
        public float delay = 0.5f;
        // private float m_lastspawnedTime = 0;

        void Start()
        {
            StartCoroutine(SpawnStoneProc());
            // m_lastspawnedTime = Time.time;
        }

        /*private void Update()
        {
            if (isGameOver)
            {
                if (m_lastspawnedTime + delay > Time.time)
                    m_lastspawnedTime = Time.time;
            }
        }*/

        private IEnumerator SpawnStoneProc()
        {
            do
            {
                yield return new WaitForSeconds(delay); // yield запоминает предыдущие состояния
                spawner.Spawn();
            }
            while (!isGameOver);
        }
    }
}