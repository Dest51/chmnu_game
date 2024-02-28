using BaseScripts.Attack;
using Events;
using Game.Spells;
using UI;
using UnityEngine;

namespace Game.Player
{
    public class PlayerAttack : BaseAttack
    {
        [SerializeField] private Transform _attackPoint = null;
        [SerializeField] private float _attackRange = 0;
        [SerializeField] private FireBall _bulletPrefab = null;
        [SerializeField] private Transform _gun = null;
        [SerializeField] private int _spellCost = 0;

        public int SpellCost { get => _spellCost; }

        private void Awake()
        {
            damage = PlayerDataStore.LoadDamage(damage);
        }
        public override void Attack()
        {
            base.Attack();
            AudioController.PlaySound("sword_attack");
        }

        public void ShootFireBall()
        {
            var fireBall = Instantiate(_bulletPrefab, _gun.position, _gun.rotation);
            fireBall.Throw(_gun);
            AudioController.PlaySound("fireball");
        }

        private void AddDamage(object[] arg)
        {
            damage += (int)arg[0];
            PlayerDataStore.SaveDamage(damage);

        }

        private void OnEnable()
        {
            EventBus.SubScribe(PotionType.DamagePotion, AddDamage);
        }

        private void OnDisable()
        {
            EventBus.UnSubscribe(PotionType.DamagePotion, AddDamage);
        }
        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_attackPoint.position, _attackRange);
        }
    }
}

