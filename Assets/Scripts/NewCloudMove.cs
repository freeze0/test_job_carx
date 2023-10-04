using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCloudMove : MonoBehaviour
{
    [SerializeField] private Transform[] targets;
    [SerializeField] private int m_targetIndex = 0;
    [SerializeField] private RainController rain;

    public Transform cloud;
    public float moveSpeed = 10f;
    private bool m_moved = false;


    public void Action()
    {
        rain.StopToRain();
        if (m_moved)
        {
            return;
        }
        m_moved = true;
        m_targetIndex++;

        if (m_targetIndex >= targets.Length)
        {
            m_targetIndex = 0;
        }

        Debug.Log("Start moving cloud", this);
    }

    private void Update()
    {
        if (!m_moved)
        {
            return;
        }
        
        Transform target = targets[m_targetIndex];
        Vector3 targetPosition = new Vector3(target.position.x, cloud.position.y, target.position.z);
        cloud.position = Vector3.Lerp(cloud.position, targetPosition, Time.deltaTime * moveSpeed); //deltatime чтобы не зависеть от частоты кадров
        
        if(Vector3.Distance(cloud.position, targetPosition) < 1.0f)
        {
            rain.StartToRain();
            
            m_moved = false;
            
        }
    }
}
