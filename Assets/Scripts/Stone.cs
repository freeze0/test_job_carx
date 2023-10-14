using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Golf
{
    public class Stone : MonoBehaviour
    {
         // если пометить event то нельз€ мен€ть извне только подписыватьс€
        public bool isAfect = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out Stone other))
            {
                if (!other.isAfect)
                {
                    GameEvents.CollisionStoneInvoke(this); //?.Invoke(); вызов ?. проверка на нулевого слушател€
                }
            }
            
        }
    }

}