using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int maxHP;
        [SerializeField] private UnityEvent onHeal;
        [SerializeField] private UnityEvent onDamage;
        [SerializeField] private UnityEvent onDie;
        [SerializeField] private HealthChangeEvent onChange;
        
        [SerializeField]private int _health;

        public void ModifyHealth(int healthDelta)
        {
            if (_health + healthDelta <= maxHP )
            {
                if(healthDelta > 0)
                    onHeal?.Invoke();
                else 
                    onDamage?.Invoke();
                
                _health += healthDelta;
                onChange?.Invoke(_health);
                
                if(_health <= 0)
                    onDie?.Invoke();
            }
        }

        public void SetHealth(int health) => _health = health;
        
        public int GetHealth() => _health;

        [Serializable] public class HealthChangeEvent : UnityEvent<int> { }
    }
}