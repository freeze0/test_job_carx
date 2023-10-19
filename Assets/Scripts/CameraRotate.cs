using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace MyGolf
{
    public class CameraRotate : MonoBehaviour
    {
        
        [SerializeField] private Transform stone;
        [SerializeField] private float camSpeed = 10f;// Reference to the stone GameObject
        private float prevTouchX;
        private bool isStoneMoving = false;
        private Vector3 lastStonePosition;
        
        private void Update()
        {
            if (Touch.activeFingers.Count == 2)
            {
                var activeTouch = Touch.activeFingers[0].currentTouch;
                RotateCamera(activeTouch);
            }
        }

        private void RotateCamera(Touch touch)
        {
            Vector3 offset = transform.position - stone.position;
            if (touch.screenPosition.x > 900)
            {
                Quaternion rotation = Quaternion.Euler(0, Time.deltaTime * camSpeed, 0);
                if (touch.screenPosition.x > 1300)
                {
                    Quaternion rotationX2 = Quaternion.Euler(0, Time.deltaTime * 2 * camSpeed, 0);
                    offset = rotationX2 * offset;
                }
                else
                {
                    offset = rotation * offset;
                }
                
            }
            else
            {
                Quaternion rotation = Quaternion.Euler(0, -Time.deltaTime * camSpeed, 0);
                offset = rotation * offset;
                if (touch.screenPosition.x < 500)
                {
                    Quaternion rotationX2 = Quaternion.Euler(0, -Time.deltaTime * 2 * camSpeed, 0);
                    offset = rotationX2 * offset;
                }
                else
                {
                    offset = rotation * offset;
                }
            }
            transform.position = stone.position + offset;
            transform.LookAt(stone);
            
        }
    }
}