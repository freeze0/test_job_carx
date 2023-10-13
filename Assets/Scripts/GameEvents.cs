using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace Golf
{
    public static class GameEvents
    {
        public static event System.Action onCollisionStone;
        public static event System.Action onStickHit;
        public static event System.Action onGameOver;


        public static void CollisionStoneInvoke(Stone stone)
        {
            onCollisionStone!.Invoke();
        }

        public static void StickHit()
        {
            onStickHit!.Invoke();
        }

        public static void GameOver()
        {
            onGameOver!.Invoke();
        }

    }
}
