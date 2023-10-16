using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGolf{
    public class FollowStone : MonoBehaviour
    {
        public Transform stone;
        [SerializeField] private Vector3 offset;

        void Update()
        {
            transform.position = stone.position + offset;
        }
    }
}