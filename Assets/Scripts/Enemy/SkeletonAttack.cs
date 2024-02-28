using BaseScripts.Attack;

namespace Enemies
{
    public class SkeletonAttack : BaseAttack
    {
        public override void Attack()
        {
            base.Attack();
            AudioController.PlaySound("skeleton_attack");
        }
    }
}

