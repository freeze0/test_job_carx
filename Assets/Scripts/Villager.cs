using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestXlab {

    public class Villager : MonoBehaviour
    {
        public List<GameObject> tools;

        private void Start()
        {
            var index = Random.Range(0, tools.Count);
            tools[index].gameObject.SetActive(true);
        }

        public void ChangeTool()
        {

        }

        private void SetActiveTools()
        {
            for (int i = 0; i < tools.Count; i++)
            {
                // tools[i].SetActive(i == index);
            }
        }
    }
}