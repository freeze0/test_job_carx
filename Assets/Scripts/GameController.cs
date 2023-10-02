using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private StoneSpawner spawner;
    [SerializeField] private CloudMove cloudMove;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            spawner.Spawn();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            cloudMove.Action();
        }
    }
}
