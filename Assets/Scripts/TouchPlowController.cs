using System;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using UnityEngine;

namespace MyGolf
{
    public class TouchPlowController : MonoBehaviour
    {
        [SerializeField] private GameObject plow;
        [SerializeField] private Camera camera;
        private Rigidbody rb;
        private float speedDivisor = 8f;
        private float positionY;
        private bool isMoving;
        private bool isRestared = false;
        
        private void Awake()
        {
            rb = plow.GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            GameEvents.onPlowHit += RestartPosition;
        }

        private void OnDisable()
        {
            GameEvents.onPlowHit -= RestartPosition;
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
                rb.MovePosition(camera.transform.position + camera.transform.forward * Time.fixedDeltaTime * positionY / speedDivisor);
            }
        }
        
        public void RestartPosition()
        {
            plow.SetActive(false);
            plow.transform.position = camera.transform.position;
            plow.SetActive(true);
            Debug.Log("Position is Restarted");
        }
    }
}
