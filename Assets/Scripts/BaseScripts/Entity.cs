using Components.Health;
using System;
using UnityEngine;

namespace Game.BaseEntity
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rigidBody = null;
        [SerializeField] protected Animator animator;
        [SerializeField] protected BaseHealthComponent healthComponent = null;

        public event Action OnDied;

        public virtual void Dead()
        {
            OnDied?.Invoke();
            Destroy(gameObject);
        }

        protected virtual void OnEnable()
        {
            healthComponent.OnHealthNull += Dead;
        }

        protected virtual void OnDisable()
        {
            healthComponent.OnHealthNull -= Dead;
        }

    }
}