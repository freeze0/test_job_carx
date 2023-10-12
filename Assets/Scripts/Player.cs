using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Player : MonoBehaviour
    {
        public Transform plow;
        public Transform helper;
        public float range = 50f;
        public float speed = 500f;
        public float power = 50f;
        private bool m_isDown = false;
        private Vector3 m_lastPosition;
        public static System.Action onHit;
        
        private void Update()
        {
            m_lastPosition = helper.position;
            m_isDown = Input.GetMouseButton(0);

            Quaternion rot = plow.localRotation;
            Quaternion toRot = Quaternion.Euler(0f, 0f, m_isDown ? range : -range);
            rot = Quaternion.RotateTowards(rot, toRot, speed*Time.deltaTime);

            plow.localRotation = rot;
        }

        public void OnCollisionStick(Collider collider)
        {
            if (collider.TryGetComponent(out Rigidbody body))
            {
                /*var dir = m_isDown ? Plow.right: -Plow.right;*/
                var dir = (helper.position - m_lastPosition).normalized;
                body.AddForce(dir * power, ForceMode.Impulse);
                
                if (collider.TryGetComponent(out Stone stone))
                {
                    onHit?.Invoke();
                    stone.isAfect = true;
                }
            }
            
            //Debug.Log(collider, this);
        }

    }
}