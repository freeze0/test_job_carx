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

public class TouchController : MonoBehaviour
{
    [SerializeField] private GameObject plow;
    private Rigidbody rb;
    //[SerializeField] private float offsetY = 29f;
    [SerializeField] private float offsetZ = 20f;
    [SerializeField] private float offsetX = 65f;
    public Vector3 worldPosition;
    private float m_SpeedDivisor = 100f;
    private float m_lastScreenPosition = 1;
    
    private void Awake()
    {
        EnhancedTouchSupport.Enable();
        rb = plow.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Touch.activeFingers.Count == 1)
        {
            
            Touch activeTouch = Touch.activeFingers[0].currentTouch;
            //Vector3 touch = new Vector3(activeTouch.screenPosition.x, activeTouch.screenPosition.y, 0);
            /*touch.z = Camera.main.nearClipPlane + 1;
            worldPosition = Camera.main.ScreenToWorldPoint(touch);
            Vector3 moveByXZ = new Vector3(offsetX, 23, worldPosition.y + offsetZ);
            rb.MovePosition(moveByXZ);
            Debug.Log($"touchX {touch.x} touchY {touch.y}");
            Debug.Log($"touchX {worldPosition.x} touchY {worldPosition.y}");
            Debug.Log($"touchX {moveByXZ.x} touchY {moveByXZ.y} touchY {moveByXZ.z}");*/
            
            rb.MovePosition(transform.position + Camera.main.transform.forward *  activeTouch.screenPosition.y / m_SpeedDivisor);
            
            
            m_lastScreenPosition = activeTouch.screenPosition.y;
            
            //Debug.Log($"Phase: {activeTouch.phase} | Position: {activeTouch.startScreenPosition}");
            //Debug.Log($"World coodinates:{activeTouch.screenPosition}");
            //Vector3 moveByXZ = new Vector3(offsetX, 23, offsetY + worldPosition.y);
            //Debug.Log($"touchX {worldPosition.x} touchY {worldPosition.y}");
            //transform.position = moveByXZ;
            /*touch.z = Camera.main.nearClipPlane + 1;
            worldPosition = Camera.main.ScreenToWorldPoint(touch);

            transform.position = worldPosition;*/

            /*Ray ray = Camera.main.ScreenPointToRay(touch);
            if (Physics.Raycast(ray, out RaycastHit hitdata))
            {
                worldPosition = hitdata.point;
            }

            transform.position = worldPosition;*/


            //Vector3 touchPosition = Camera.main.WorldToScreenPoint(plow.transform.position);
            //Debug.Log($"pos {touchPosition}");
        }
    }
}
