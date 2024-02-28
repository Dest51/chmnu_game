using UnityEngine;

namespace BaseScripts.Attack
{
    public class BaseAttack : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _hitCollider;
        [SerializeField] protected int damage = 0;

        public virtual void Attack()
        {
            Vector3 hitPosition = transform.TransformPoint(_hitCollider.offset);
            Collider2D[] hit = Physics2D.OverlapCircleAll(hitPosition, _hitCollider.radius);

            for (int i = 0; i < hit.Length; i++)
            {
                if (!GameObject.Equals(hit[i].gameObject, gameObject))
                {
                    IDestructible destructable = hit[i].gameObject.GetComponent<IDestructible>();
                    if (destructable != null)
                    {
                        destructable.Hit(damage);
                    }
                }
            }
        }
    }
}
