using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGolf
{
    public class FollowStone : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        public Transform stone;

        private void Update()
        {
            transform.position = stone.position + offset;
            transform.LookAt(stone);
        }

    }
}
