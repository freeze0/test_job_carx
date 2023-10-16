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
        private Rigidbody rb;
        private float speedDivisor = 5f;
        private Vector3 _cameraOffset = new Vector3(2,0,0);
        private float _positionY;
        private bool isMoving;
        
        private void Awake()
        {
            EnhancedTouchSupport.Enable();
            rb = plow.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Touch.activeFingers.Count == 1)
            {
                Touch activeTouch = Touch.activeFingers[0].currentTouch;
                _positionY = GetTouchPositionY(activeTouch);
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }

        private void FixedUpdate()
        {
            if (isMoving)
            {
                rb.MovePosition(transform.position + camera.transform.forward * Time.deltaTime * _positionY / speedDivisor + _cameraOffset);
            }
        }

        private float GetTouchPositionY(Touch touch)
        {
            return touch.screenPosition.y;
        }
        
        
    }
    
}
