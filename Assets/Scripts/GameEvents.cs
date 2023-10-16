using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace MyGolf
{
    public static class GameEvents
    {
       public static event System.Action onPlowHit;

       public static void PlowHit()
       {
           onPlowHit?.Invoke();
       }

       /*public static void OnCollisionEndPoint()
       {
           
       }*/
    }
}
