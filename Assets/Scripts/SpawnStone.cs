using System.Collections.Generic;
using UnityEngine;

namespace MyGolf
{
    public class SpawnStone : MonoBehaviour
    {
        [SerializeField] private List<GameObject> prefabList = new List<GameObject>();

        public GameObject Spawn()
        {
            GameObject prefab = GetRandomPrefab();
            return Instantiate(prefab, transform.position, Quaternion.identity);
        }

        private GameObject GetRandomPrefab()
        {
            int index = Random.Range(0, prefabList.Count);
            return prefabList[index];
        }
    }
}
