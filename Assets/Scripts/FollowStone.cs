using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGolf{
    public class FollowStone : MonoBehaviour
    {
        public Transform stone;
        [SerializeField] private Vector3 offset;
        
        private void Update()
        {
            transform.position = stone.position + offset;
            transform.LookAt(stone);
        }
    }
}