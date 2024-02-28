using Game.BaseEntity;
using Game.Player;
using UnityEngine;

namespace Enemies
{
    public class Skeleton : Entity
    {
        [SerializeField] private SkeletonMove _skeletonMove;
        [SerializeField] private SkeletonAttack _skeletonAttack;
        [SerializeField] private int _deadScore;

        private bool _isAttack = false;

        private void Update()
        {
            if (!_isAttack)
            {
                _skeletonMove.Move();
                animator.SetFloat("Speed", _skeletonMove.Speed);
            }
        }

        public void Attack()
        {
            _skeletonAttack.Attack();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Player player = collision.collider.GetComponent<Player>();
            if (player != null)
            {
                _isAttack = true;
                animator.SetBool("IsAttack", true);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            Player player = collision.collider.GetComponent<Player>();
            if (player != null)
            {
                _isAttack = false;
                animator.SetBool("IsAttack", false);
            }

        }

        public override void Dead()
        {
            base.Dead();
        }



    }
}
