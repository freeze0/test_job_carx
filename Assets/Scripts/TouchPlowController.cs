using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using UnityEngine;

namespace MyGolf
{
    public class TouchPlowController : MonoBehaviour
    {
        [SerializeField] private GameObject plow;
        [SerializeField] private Camera camera;
        private Rigidbody rb;
        private float speedDivisor = 5.0f;
        private Vector3 cameraOffset = new Vector3(2,0,0);
        private float positionY;
        private bool isMoving;
        private bool isRestared = false;
        
        private void Awake()
        {
            rb = plow.GetComponent<Rigidbody>();
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
                    Debug.Log($"restarted to {camera.transform.localPosition - camera.transform.forward}");
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
            transform.position = camera.transform.position;
        }
    }
}
