using UnityEngine;



    public class StoneSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] prefabs;
        [SerializeField] private Transform spawnPoint;

        public GameObject Spawn()
        {
            var prefab = GetRandomPrefab();
            
            if (prefab == null)
            {
                Debug.Log("Spawner - Prefab is null");
                return null;
            }

            return Instantiate(prefab, transform.position, Quaternion.identity);
        }

        private GameObject GetRandomPrefab()
        {

            if (prefabs.Length == 0)
            {
                Debug.Log("Prefab is empty");
                return null;
            }

            int index = Random.Range(0, prefabs.Length);
            return prefabs[index];
        }
    }
