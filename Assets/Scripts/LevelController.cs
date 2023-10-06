using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf { 

    public class LevelController : MonoBehaviour
    {
        public StoneSpawner spawner;
        public bool isGameOver = false;
        public float delay = 0.05f;
    
        void Start()
        {
            StartCoroutine(SpawnStoneProc());
        }

        private IEnumerator SpawnStoneProc()
        {
            do
            {
                yield return new WaitForSeconds(delay);
                spawner.Spawn();
            }
            while (!isGameOver);
        }
    }
}