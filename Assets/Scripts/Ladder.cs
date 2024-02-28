using Game.Player;
using UnityEngine;

namespace Objects
{
    public class Ladder : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerMove playerMove = collision.GetComponent<PlayerMove>();
            if (playerMove != null)
                playerMove.IsLadder(true);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            PlayerMove playerMove = collision.GetComponent<PlayerMove>();
            if (playerMove != null)
                playerMove.IsLadder(false);
        }
    }
}
