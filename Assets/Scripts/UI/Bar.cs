using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Bar : MonoBehaviour
    {
        [SerializeField] private Image _fill;
        public void ChangeValueProgress(float value, float maxValue)
        {
            _fill.fillAmount = value / maxValue;
        }

    }
}
