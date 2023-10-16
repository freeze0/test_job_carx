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
        [SerializeField] private float _speed = 25;
        private float speedMod = 10.0f;
        private Rigidbody rb;
        private float speedDivisor = 5.0f;
        private Vector3 _cameraOffset = new Vector3(2,0,0);
        private float _positionY;
        private bool isMoving;
        private Vector3 point;
        private Vector3 prevPos;
        
        private void Awake()
        {
            EnhancedTouchSupport.Enable();
            rb = plow.GetComponent<Rigidbody>();
        }

        private void Update()
        {

            if (Touch.activeFingers.Count == 2)
            {
                Touch activeTouch = Touch.activeFingers[0].currentTouch;
                RotateAroundStone(camera.transform, activeTouch);
            }
            
            if (Touch.activeFingers.Count == 1)
            {
                plow.SetActive(true);
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

        private void RotateAroundStone(Transform someTransform, Touch touch)
        {
            Transform stoneTransform = stone.transform;
            
            Vector3 offset = someTransform.position - stoneTransform .position;
            if (touch.screenPosition.x > 900)
            {
                Quaternion rotation = Quaternion.Euler(0, _speed * Time.deltaTime, 0);
                offset = rotation * offset;
            }
            else
            {
                Quaternion rotation = Quaternion.Euler(0, -_speed * Time.deltaTime, 0);
                offset = rotation * offset;
            }
            someTransform.position = stoneTransform.position + offset;
            someTransform.LookAt(stoneTransform );
        }

        private void RestartPosition()
        {
            
        }
        
    }
}
