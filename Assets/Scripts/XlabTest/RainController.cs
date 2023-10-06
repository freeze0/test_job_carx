using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_ParticleSystem;

    public void StartToRain()
    {
        Debug.Log("It's start to rain");
        m_ParticleSystem.Play();
    }

    public void StopToRain()
    {
        Debug.Log("It's stop to rain");
        m_ParticleSystem.Pause();
        m_ParticleSystem.Clear();
    }

}
