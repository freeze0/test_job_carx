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
        [SerializeField] private float camSpeed = 10f;
        private Quaternion currentRotation;
        
        private void Update()
        {
            if (Touch.activeFingers.Count == 2)
            {
                var activeTouch = Touch.activeFingers[0].currentTouch;
                RotateCamera(activeTouch); // сразу мен€ть трансформ когда ротейтим камеру
            }
        }

        private void RotateCamera(Touch touch)
        {
            Vector3 offset = transform.position - stone.position;
            if (touch.screenPosition.x > 1250)
            {
                Quaternion rotation = Quaternion.Euler(0, Time.deltaTime * 2 * camSpeed, 0);
                if (touch.screenPosition.x > 1800)
                {
                    Quaternion rotationX2 = Quaternion.Euler(0, Time.deltaTime * 4 * camSpeed, 0);
                    offset = rotationX2 * offset;
                }
                else
                {
                    offset = rotation * offset;
                }
                
            }
            else
            {
                Quaternion rotation = Quaternion.Euler(0, -Time.deltaTime * 2 * camSpeed, 0);
                offset = rotation * offset;
                if (touch.screenPosition.x < 700)
                {
                    Quaternion rotationX2 = Quaternion.Euler(0, -Time.deltaTime * 4 * camSpeed, 0);
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