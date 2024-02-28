using Events;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryUIButton : MonoBehaviour
    {
        [SerializeField] private Image _itemImage = null;
        [SerializeField] private Button _myButton = null;

        public void InitItem(InventoryItem inventoryItem)
        {
            _itemImage.sprite = inventoryItem.ItemImage;
            _myButton.onClick.AddListener(() => Click(inventoryItem.PotionType, inventoryItem.ValueBaff));
        }

        public void Click(PotionType potionType, int value)
        {
            EventBus.BroadCast(potionType, value);
        }

    }
}
