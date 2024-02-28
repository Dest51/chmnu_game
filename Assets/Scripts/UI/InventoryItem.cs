using UnityEngine;

namespace UI
{
    public enum PotionType { HpPotion, HpMaxPotion, MpPotion, MpMaxPotion, DamagePotion, SpeedPotion }
    [CreateAssetMenu(menuName = ("InventoryItem/Potion"))]
    public class InventoryItem : ScriptableObject
    {
        [SerializeField] private Sprite _itemImage = null;
        [SerializeField] private int _valueBaff = 0;
        [SerializeField] private PotionType _potionType = PotionType.HpMaxPotion;

        public Sprite ItemImage { get => _itemImage; }

        public int ValueBaff { get => _valueBaff; }
        public PotionType PotionType { get => _potionType; }

    }
}
