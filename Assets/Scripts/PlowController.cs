using System;
using System.Collections;
using System.Collections.Generic;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using UnityEngine;

namespace MyGolf
{
    public class PlowController : MonoBehaviour
    {
        
        [SerializeField] private GameObject plow;
        [SerializeField] private Camera camera;
        [SerializeField] private Vector3 hitOffset = new Vector3(2f, 1f, -0.15f);
        private Rigidbody rb;
        private float speedDivisor = 7.2f;
        private float positionY;
        private bool isMoving;
        private bool isRestared = false;
        private Vector3 newRotation = new Vector3(0.0f, 0.0f, 0.0f);
        public GameObject Plow => plow;
        
        private void Awake()
        {
            rb = plow.GetComponent<Rigidbody>();
            isRestared = false;
            plow.SetActive(false);
        }

        private void OnEnable()
        {
            Quaternion _newRot = Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, 180);
            plow.transform.rotation = _newRot;
        }

        private void OnDisable()
        {
            isMoving = false;
            isRestared = false;
        }

        private void Update()
        {   
            if (Touch.activeFingers.Count == 1)
            {
                plow.SetActive(true);
                Touch activeTouch = Touch.activeFingers[0].currentTouch;
                positionY = activeTouch.screenPosition.y;
                isMoving = true;
                isRestared = false;
            }
            else
            {
                plow.SetActive(false);
                isMoving = false;
                if (!isRestared)
                {
                    RestartPosition();
                    isRestared = true;
                }
            }
        }

        private void FixedUpdate()
        {
            if (isMoving)
            {
                rb.MovePosition(camera.transform.position + hitOffset + camera.transform.forward * Time.fixedDeltaTime * positionY / speedDivisor);
            }
        }
        
        private void RestartPosition()
        {
            plow.transform.position = camera.transform.position;  
            Debug.Log("Position is Restarted");
        }
    }
}
