using Components.Health;
using Components.Mana;
using Game.Player;
using UnityEngine;

namespace UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private Player _player = null;
        [SerializeField] private Bar _healthBar = null;
        [SerializeField] private Bar _manaBar = null;
        [SerializeField] private MovePanel _movePanel = null;
        [SerializeField] private BaseHealthComponent _playerHealthComponent = null;
        [SerializeField] private PlayerManaComponent _playerManaComponent = null;
        [SerializeField] private Inventory _invertoryManage;

        static private HUD _instance;
        public static HUD Instance { get => _instance; }

        private void Awake()
        {
            _instance = this;
        }

        public void CreateIvnentoryItem(InventoryItem item)
        {
            _invertoryManage.CreateIvnentoryItem(item);
        }

        private void UpdateHealthBar(int value, int maxValue)
        {
            _healthBar.ChangeValueProgress(value, maxValue);
        }
        protected void UpdateManaBar(float value, float maxValue)
        {
            _manaBar.ChangeValueProgress(value, maxValue);
        }
        public void ShowLosePanel()
        {
            _movePanel.ShowPanel();
        }
        private void OnEnable()
        {
            _playerHealthComponent.OnChangeHP += UpdateHealthBar;
            _playerManaComponent.OnChangeMana += UpdateManaBar;
            _player.OnDied += ShowLosePanel;
        }
        private void OnDisable()
        {
            _playerHealthComponent.OnChangeHP -= UpdateHealthBar;
            _playerManaComponent.OnChangeMana -= UpdateManaBar;
            _player.OnDied -= ShowLosePanel;
        }

    }
}
