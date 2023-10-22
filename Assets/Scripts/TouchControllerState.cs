using System;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using UnityEngine;

namespace MyGolf
{
    public class TouchControllerState : MonoBehaviour
    {   
        [SerializeField] private GameObject plow;
        [SerializeField] private Camera camera;
        [SerializeField] private Vector3 hitOffset = new Vector3(2f, 1f, -0.15f);
        private Rigidbody rb;
        private float speedDivisor = 7.2f;
        private float positionY;
        private bool isMoving;
        private bool isRestared = false;
        public GameObject Plow => plow;
        private void Awake()
        {
            rb = plow.GetComponent<Rigidbody>();
            isRestared = false;
            plow.SetActive(false);
        }

        private void OnEnable()
        {
           //GameEvents.onPlowHit += RestartPosition;
        }

        private void OnDisable()
        {
            GameEvents.onPlowHit -= RestartPosition;
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
        
        public void RestartPosition()
        {
            plow.transform.position = camera.transform.position;  
            Debug.Log("Position is Restarted");
        }   
    }
}
