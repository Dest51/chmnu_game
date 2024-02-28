using Game.BaseEntity;
using System;
using UnityEngine;

namespace UI
{
    public class ScoreEnemy : MonoBehaviour
    {
        [SerializeField] private int _dieScore = 1;
        [SerializeField] private Entity _entity = null;

        public static event Action<int> OnNeedChangeScore;

        public void NeedChangeScore()
        {
            OnNeedChangeScore?.Invoke(_dieScore);
        }

        private void OnEnable()
        {
            _entity.OnDied += NeedChangeScore;
        }

        private void OnDisable()
        {
            _entity.OnDied -= NeedChangeScore;

        }
    }
}
