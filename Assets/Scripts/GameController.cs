using UnityEngine;

//name space TestXlab.Controllers ��� ��������������� ������������� ��������

namespace TestXlab { 
    public class GameController : MonoBehaviour
    {
        [SerializeField] private StoneSpawner spawner;
        [SerializeField] private NewCloudMove newCloudMove;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X)) 
            {
                spawner.Spawn();
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                newCloudMove.Action();
            }
        }
}
}
