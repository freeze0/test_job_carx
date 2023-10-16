using System;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Debug = UnityEngine.Debug;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

namespace MyGolf
{
    public class TouchController : MonoBehaviour
    {
        [SerializeField] private GameObject plow;
        [SerializeField] private Camera camera;
        [SerializeField] private GameObject stone;
        private Rigidbody rb;
        private float speedDivisor = 5.0f;
        private Vector3 cameraOffset = new Vector3(2,0,0);
        private float positionY;
        private bool isMoving;
        private bool isRestared = false;
        
        private void Awake()
        {
            EnhancedTouchSupport.Enable();
            rb = plow.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Touch.activeFingers.Count == 1)
            {
                plow.SetActive(true);
                Touch activeTouch = Touch.activeFingers[0].currentTouch;
                positionY = GetTouchPositionY(activeTouch);
                isMoving = true;
                isRestared = false;
            }
            else
            {
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
                rb.MovePosition(transform.position + camera.transform.forward * Time.deltaTime * positionY / speedDivisor + cameraOffset);
            }
        }

        private float GetTouchPositionY(Touch touch)
        {
            return touch.screenPosition.y;
        }

        public void RestartPosition()
        {
            rb.transform.Translate(transform.position - camera.transform.forward * Time.deltaTime);
        }
    }
}
