using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPoint;

    public void Spawn() 
    { 
        GameObject.Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
