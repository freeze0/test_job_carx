using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Player : MonoBehaviour
    {
        public Transform Plow;
        public Transform Helper;
        public float range = 50f;
        public float speed = 500f;
        public float power = 50f;
        private bool m_isDown = false;
        private Vector3 m_lastPosition;


        private void Update()
        {
            m_lastPosition = Helper.position;
            m_isDown =Input.GetMouseButton(0);

            Quaternion rot = Plow.localRotation;
            Quaternion toRot = Quaternion.Euler(0f, 0f, m_isDown ? range : -range);
            rot = Quaternion.RotateTowards(rot, toRot, speed*Time.deltaTime);

            Plow.localRotation = rot;
        }

        public void OnCollisionStick(Collider collider)
        {
            if (collider.TryGetComponent(out Rigidbody body))
            {
                /*var dir = m_isDown ? Plow.right: -Plow.right;*/
                var dir = (Helper.position - m_lastPosition).normalized;
                body.AddForce(dir * power, ForceMode.Impulse);
                
                if (collider.TryGetComponent(out Stone stone))
                {
                    stone.isAfect = true;
                }
            }
            //Debug.Log(collider, this);
        }

    }
}