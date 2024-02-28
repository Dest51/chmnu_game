using Events;
using UI;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 0;
        [SerializeField] private Transform _groundChacker;
        [SerializeField] private float _groundRadius = 0;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _climbingLadderSpeed = 0;
        [SerializeField] private int _myLayer = 0;
        [SerializeField] private int _ignoreLayer = 0;
        [SerializeField] private float _speed = 0;

        private bool _isLadderActive = false;
        private bool _facingRight = true;
        private bool _isGround;

        public bool IsGround { get => _isGround; }

        private void Awake()
        {
            _speed = PlayerDataStore.LoadSpeed(_speed);
        }

        public void Move(Rigidbody2D rigidBody) 
        {
            Vector2 velocity = rigidBody.velocity;
            velocity.x = Input.GetAxis("Horizontal") * _speed;
            rigidBody.velocity = velocity;

            if(Input.GetAxis("Horizontal") > 0 && !_facingRight)
            {
                Flip();
            }
            else if(Input.GetAxis("Horizontal") < 0 && _facingRight)
            {
                Flip();
            }
        }

        public void MoveOnLadder(Rigidbody2D rigidBody)
        {
            if (_isLadderActive)
            {
                rigidBody.gravityScale = 0;
                Vector2 velocity = rigidBody.velocity;
                velocity.y = Input.GetAxis("Vertical") * _climbingLadderSpeed;
                rigidBody.velocity = velocity;
            }
            else
                rigidBody.gravityScale = 1;

        }

        public void Jump(Rigidbody2D rigidBody)
        {
            ChakingGround();
            if (_isGround)
            {
                rigidBody.AddForce(Vector2.up * _jumpForce);
                AudioController.PlaySound("jumping");
            }
        }

        public void ChakingGround()
        {
            _isGround = Physics2D.OverlapCircle(_groundChacker.position, _groundRadius, _groundLayer);
        }

        private void Flip()
        {
            _facingRight = !_facingRight;
            transform.Rotate(0f, 180f, 0f);
        }

        public void IsLadder(bool isLadderActive)
        {
            Physics2D.IgnoreLayerCollision(_myLayer, _ignoreLayer, isLadderActive);
            _isLadderActive = isLadderActive;
        }

        private void AddSpeed(object[] arg)
        {
            _speed += (int)arg[0];
            PlayerDataStore.SaveSpeed(_speed);
        }

        private void OnEnable()
        {
            EventBus.SubScribe(PotionType.SpeedPotion, AddSpeed);
        }

        private void OnDisable()
        {
            EventBus.UnSubscribe(PotionType.SpeedPotion, AddSpeed);

        }


    }
}