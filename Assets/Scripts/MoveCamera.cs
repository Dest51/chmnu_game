using UnityEngine;

namespace Game.Camera
{
    public class MoveCamera : MonoBehaviour
    {
        [SerializeField] private Transform _player = null;
        [SerializeField] private float _dumping = 0;

        private Vector3 _target = Vector3.zero;
        private Vector2 _offset = new Vector2(2f, 1f);
        private int _lastX = 0;
        private int _currentX = 0;
        private bool isLookingLeft = false;
            
        private void LateUpdate()
        {
            if (_player == null)
                return;

            _currentX = Mathf.RoundToInt(_player.position.x);
            if (_currentX > _lastX)
                isLookingLeft = false;
            else if(_currentX < _lastX)
                isLookingLeft = true;
            _lastX = Mathf.RoundToInt(_player.position.x);
            Move();
        }

        private void Move()
        {
            if (isLookingLeft)
            {
                _target = new Vector3(_player.position.x - _offset.x, _player.position.y + _offset.y, transform.position.z);

                transform.position = Vector3.Lerp(transform.position, _target, _dumping * Time.deltaTime);
            }
            else
            {
                _target = new Vector3(_player.position.x + _offset.x, _player.position.y + _offset.y, transform.position.z);

                transform.position = Vector3.Lerp(transform.position, _target, _dumping * Time.deltaTime);
            }
        }

    }
}
