using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScoreSystem : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;

        private int _score;

        public void UpdateScore(int count)
        {
            _score += count;
            _scoreText.text = _score.ToString();
        }
        private void OnEnable()
        {
            ScoreEnemy.OnNeedChangeScore += UpdateScore;
        }

        private void OnDisable()
        {
            ScoreEnemy.OnNeedChangeScore -= UpdateScore;
        }
    }
}
