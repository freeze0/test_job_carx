using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace MyGolf
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private MainMenuState mainMenuState;


        private void Awake()
        {
            EnhancedTouchSupport.Enable();
        }

        private void Start()
        {
            mainMenuState.gameObject.SetActive(true);
        }
    }
}
