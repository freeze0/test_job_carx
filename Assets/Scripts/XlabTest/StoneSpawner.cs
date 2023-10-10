using UnityEngine;



    public class StoneSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] prefabs;
        [SerializeField] private Transform spawnPoint;

        public void Spawn()
        {
            if (prefabs == null)
            {
                Debug.Log("Prefab is null");
                return;
            }

            var prefab = GetRandomPrefab();
            Debug.Log("Stone spawned");
            GameObject.Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }

        private GameObject GetRandomPrefab()
        {

            if (prefabs.Length == 0)
            {
                Debug.Log("Prefab is empty");
                return null;
            }

            int index = Random.Range(0, prefabs.Length);
            var prefab = prefabs[index];
            return prefab;
        }
    }
