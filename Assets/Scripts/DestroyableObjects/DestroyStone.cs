using UnityEngine;

namespace DestryableObjects
{
    public class DestroyStone : MonoBehaviour, IDestructible
    {
        [SerializeField] protected float maxHealth = 0;

        private float _health = 0;

        protected virtual void Awake()
        {
            _health = maxHealth;
        }

        public void Dead()
        {
            Destroy(gameObject);
        }

        public void Hit(int damage)
        {
            if (_health <= 0)
                return;

            _health -= damage;
            if (_health <= 0)
            {
                Dead();
            }
        }
    }
}
