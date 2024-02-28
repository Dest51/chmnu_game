using UnityEngine;
using System.Collections;
using Game.BaseEntity;
using Components.Mana;

namespace Game.Player
{
    public class Player : Entity
    {
        [SerializeField] private PlayerMove _playerMove = null;
        [SerializeField] private PlayerAttack _playerAttack = null;
        [SerializeField] private float _hitDelay = 0;
        [SerializeField] private PlayerManaComponent _manaComponent = null;

        private Coroutine _coroutine;

        private void Start()
        {
            AudioController.PlayMusicLoop("mainGameMusic");
        }

        private void FixedUpdate()
        {
            _playerMove.Move(rigidBody);
            _playerMove.MoveOnLadder(rigidBody);
            animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerMove.Jump(rigidBody);
            }

            animator.SetBool("IsJump", _playerMove.IsGround);
            _playerMove.ChakingGround();

            if (Input.GetButtonDown("Fire1"))
            {
                StartIEAttack();
            }

            if (Input.GetButtonDown("Fire2") && _manaComponent.CurrentMana >= _playerAttack.SpellCost)
            {
                _playerAttack.ShootFireBall();
                _manaComponent.ChangeCurrentMana(_playerAttack.SpellCost);
            }
        }

        private void StartIEAttack()
        {
            _coroutine = StartCoroutine(IEAttack());
        }

        private IEnumerator IEAttack()
        {
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(_hitDelay);
            _playerAttack.Attack();

        }

        private void OnDestroy()
        {
            if (_coroutine != null)
            {
                PlayerDataStore.ClearPrefs();
                StopCoroutine(_coroutine);
            }
        }


    }
}
