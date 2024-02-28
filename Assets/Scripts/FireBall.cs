using UnityEngine;

namespace Game.Spells
{
    public class FireBall : MonoBehaviour
    {
        [SerializeField] private int _damage = 0;
        [SerializeField] private Rigidbody2D _rigidBody = null;
        [SerializeField] private float _shootPower = 0;

        public void Throw(Transform direction)
        {
            _rigidBody.AddForce(direction.right * _shootPower);
            Destroy(gameObject, 2);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDestructible destructible = collision.gameObject.GetComponent<IDestructible>();
            if (destructible != null && collision.tag != "Player")
            {
                destructible.Hit(_damage);
                Destroy(gameObject);
            }
        }
    }
}
