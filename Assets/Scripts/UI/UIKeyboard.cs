using UI;
using UnityEngine;

namespace KeyboardActions
{
    public class UIKeyboard : MonoBehaviour
    {
        [SerializeField] MovePanel _inventoryPanel;

        private void Update()
        {
            if (Input.GetKeyDown("i"))
            {
                _inventoryPanel.ShowInventory();
            }
            else if (Input.GetKeyDown("i"))
            {
                _inventoryPanel.HideInventory();
            }

        }
    }
}
