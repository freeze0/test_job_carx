using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace Golf
{
    public static class GameEvents
    {
        public static event System.Action onCollisionStones;
        public static event System.Action onStickHit;


        public static void CollisionStoneInvoke(Stone stone)
        {
            onCollisionStones?.Invoke();
        }

        public static void StickHit()
        {
            onStickHit?.Invoke();
        }

    }
}
