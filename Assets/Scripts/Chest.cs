using Game.Player;
using UI;
using UnityEngine;

namespace Objects.Chest
{
    public class Chest : MonoBehaviour
    {
        [SerializeField] private InventoryItem[] _inventoryItems;
        public void OnCollisionEnter2D(Collision2D collision)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                AudioController.PlaySound("chest_grab");
                int randomItem = Random.Range(0, _inventoryItems.Length);
                HUD.Instance.CreateIvnentoryItem(_inventoryItems[randomItem]);
                Destroy(gameObject);
            }

        }
    }
}
