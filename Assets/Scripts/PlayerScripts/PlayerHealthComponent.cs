using Events;
using UI;

namespace Components.Health
{
    public class PlayerHealthComponent : BaseHealthComponent
    {

        override public void Awake()
        {

            maxHealth = PlayerDataStore.LoadMaxHealth(maxHealth);
            base.Awake();

        }
        public void DrinkHPPotion(object[] arg2)
        {
            health += (int)arg2[0];

            if (health > maxHealth)
            {
                health = maxHealth;
            }

            ChangeHealthValue(health);
        }

        public void DrinkMaxHpPotion(object[] arg2)
        {
            health += (int)arg2[0];

            if (health > maxHealth)
            {
                health = maxHealth;
            }

            ChangeHealthValue(health);
            PlayerDataStore.SaveMaxHealth(maxHealth);
        }

        private void OnEnable()
        {
            EventBus.SubScribe(PotionType.HpPotion, DrinkHPPotion);
            EventBus.SubScribe(PotionType.HpMaxPotion, DrinkMaxHpPotion);
        }

        private void OnDisable()
        {
            EventBus.UnSubscribe(PotionType.HpPotion, DrinkHPPotion);
            EventBus.UnSubscribe(PotionType.HpMaxPotion, DrinkMaxHpPotion);
        }

    }
}
