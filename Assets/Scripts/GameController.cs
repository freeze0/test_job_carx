using System.Collections.Generic;
using UnityEngine;

//name space TestXlab.Controllers дл€ разграничивани€ использовани€ скриптов

namespace TestXlab { 
    public class GameController : MonoBehaviour
    {
        [SerializeField] private StoneSpawner spawner;
        [SerializeField] private NewCloudMove newCloudMove;
        public List<Villager> villagers;
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space key down");
                foreach (var villager in villagers)
                {
                    villager.ChangeTool();
                }
            }
        }
}
}
