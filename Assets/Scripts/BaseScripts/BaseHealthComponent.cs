using System;
using UnityEngine;

namespace Components.Health
{
    public class BaseHealthComponent : MonoBehaviour, IDestructible
    {
        public event Action OnHealthNull;
        public event Action<int, int> OnChangeHP;

        [SerializeField] protected int maxHealth = 0;
        [SerializeField] protected int health = 0;

        public virtual void Awake()
        {
            health = maxHealth;
        }

        public virtual void Hit(int damage)
        {
            if (health <= 0)
                return;

            health -= damage;
            OnChangeHP?.Invoke(health, maxHealth);
            if (health <= 0)
            {
                OnHealthNull?.Invoke();
            }
        }

        public void ChangeHealthValue(int health)
        {
            OnChangeHP?.Invoke(health, maxHealth);
        }
    }
}
