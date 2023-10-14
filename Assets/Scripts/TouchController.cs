using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.activeFingers.Count == 1)
        {
            Touch activeTouch = Touch.activeFingers[0].currentTouch;
            //Debug.Log($"Phase: {activeTouch.phase} | Position: {activeTouch.startScreenPosition}");
            Debug.Log($"World coodinates:{activeTouch.screenPosition}");
            Vector3 touch = new Vector3(activeTouch.screenPosition.x, activeTouch.screenPosition.y, 0);
        }
        
    }
}
