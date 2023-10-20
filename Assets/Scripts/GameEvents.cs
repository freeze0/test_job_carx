using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace MyGolf
{
    public static class GameEvents
    {
       public static event System.Action onPlowHit;
       public static event System.Action onStoneStop;
       public static event System.Action onCollisionFinish;
       

       public static void PlowHit()
       {
           onPlowHit?.Invoke();
       }

       public static void OnStoneStop()
       {
           onStoneStop?.Invoke();
       }

       public static void OnCollisionFinish()
       {
           onCollisionFinish?.Invoke();
       }
       
    }
}
