using UnityEngine;

namespace UI
{
    public class MovePanel : MonoBehaviour
    {
        [SerializeField] protected Animator animator = null;

        protected bool _isShowedInventory = false;

        public void ShowPanel() // LoosePanel
        {
            animator.SetBool("isShowed", true);
        }

        public void HideInventory()
        {
            AudioController.PlaySound("inventory_close");
            animator.SetBool("IsShowed", false);
            _isShowedInventory = false;
        }

        public void HidePanel()
        {
            animator.SetBool("isShowed", false);
        }


        public void ShowInventory()
        {
            if (_isShowedInventory)
            {
                animator.SetBool("IsShowed", false);
                _isShowedInventory = false;
                AudioController.PlaySound("inventory_close");

            }
            else
            {
                animator.SetBool("IsShowed", true);
                _isShowedInventory = true;
                AudioController.PlaySound("inventory_open");
            }
        }
    }
}
