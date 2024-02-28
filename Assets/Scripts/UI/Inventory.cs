using UI;
using UnityEngine;

namespace UI
{
    public class Inventory : MovePanel
    {
        [SerializeField] private Transform _parentInvertoryItem = null;
        [SerializeField] private InventoryUIButton _buttonPrefab = null;

        public void CreateIvnentoryItem(InventoryItem item)
        {
            InventoryUIButton inventoryUIButton = Instantiate(_buttonPrefab);
            inventoryUIButton.InitItem(item);
            inventoryUIButton.transform.SetParent(_parentInvertoryItem);
            inventoryUIButton.transform.position = _parentInvertoryItem.transform.position;
            inventoryUIButton.transform.localScale = Vector3.one;

        }
    }
}
