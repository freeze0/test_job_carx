using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace MyGolf
{
    public class CameraRotateState : MonoBehaviour
    {
        
        [SerializeField] private Transform stone;
        [SerializeField] private float camSpeed = 10f;
        [SerializeField] private float camSpeedMultiplier = 4f;
        [SerializeField] private RectTransform shootButton;
        private Quaternion currentRotation;
        private float halfScreen = Screen.width / 2.0f;
        
        private void Update()
        {
            if (Touch.activeFingers.Count == 1)
            {
                var activeTouch = Touch.activeFingers[0].currentTouch;
                if (activeTouch.screenPosition.y > shootButton.rect.yMax * 2)
                {
                    RotateCamera(activeTouch);
                }
            }
        }
        
        private void RotateCamera(Touch touch)
        { 
            Vector3 offset = transform.position - stone.position;
            if (touch.screenPosition.x > halfScreen)
            {
                Quaternion rotation = Quaternion.Euler(0, Time.deltaTime * camSpeed, 0);
                if (touch.screenPosition.x > halfScreen + halfScreen/2)
                {
                    Quaternion rotationX2 = Quaternion.Euler(0, Time.deltaTime * camSpeedMultiplier * camSpeed, 0);
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
                if (touch.screenPosition.x < halfScreen - halfScreen/2)
                {
                    Quaternion rotationX2 = Quaternion.Euler(0, -Time.deltaTime * camSpeedMultiplier * camSpeed, 0);
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