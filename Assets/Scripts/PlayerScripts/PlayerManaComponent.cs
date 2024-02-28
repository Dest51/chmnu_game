using Events;
using System;
using UI;
using UnityEngine;

namespace Components.Mana
{
    public class PlayerManaComponent : MonoBehaviour
    {
        public event Action<float, float> OnChangeMana;

        [SerializeField] private float _maxMana = 0;

        [SerializeField] private float _mana = 0;
        public float CurrentMana => _mana;

        private void Awake()
        {
            _mana = _maxMana;
            _mana = PlayerDataStore.LoadMaxMana(_mana);
        }

        public void ChangeCurrentMana(float value)
        {
            _mana -= value;
            OnChangeMana?.Invoke(_mana, _maxMana);
        }

        private void AddMana(object[] arg)
        {
            _mana += (int)arg[0];

            if (_mana > _maxMana)
            {
                _mana = _maxMana;
            }

            OnChangeMana?.Invoke(_mana, _maxMana);
        }
        private void AddMaxMana(object[] arg)
        {
            _mana += (int)arg[0];

            if (_mana > _maxMana)
            {
                _mana = _maxMana;
            }

            OnChangeMana?.Invoke(_mana, _maxMana);
            PlayerDataStore.SaveMaxMana(_maxMana);
        }

        private void OnEnable()
        {
            EventBus.SubScribe(PotionType.MpPotion, AddMana);
            EventBus.SubScribe(PotionType.MpMaxPotion, AddMaxMana);
        }

        private void OnDisable()
        {
            EventBus.UnSubscribe(PotionType.MpPotion, AddMana);
            EventBus.UnSubscribe(PotionType.MpMaxPotion, AddMaxMana);
        }

    }
}
