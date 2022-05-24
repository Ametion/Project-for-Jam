using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class OnCollisionEnter : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private EnterEvent _event;

        private void OnCollisionEnter2D(Collision2D collider)
        {
            if(collider.gameObject.CompareTag(_tag))
            {
                _event?.Invoke(collider.gameObject);
            }
        }
    }

    [Serializable] public class EnterEvent : UnityEvent<GameObject> { }
}