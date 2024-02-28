using UnityEngine;

namespace Enemies
{
    public class SkeletonMove : MonoBehaviour
    {
        [SerializeField] private Transform[] _wayPoints = null;
        [SerializeField] private float _speed = 0;

        private int _index = 0;
        private bool _flagMove = true;

        public float Speed => _speed;

        public void Move()
        {
            if (_flagMove)
            {
                transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_index].transform.position, _speed * Time.deltaTime);

                if (transform.position == _wayPoints[_index].transform.position)
                {
                    _index++;
                    transform.Rotate(0f, 180f, 0f);
                }

                if (_index == _wayPoints.Length)
                {
                    _index = 0;
                }
            }
        }

        public void StartMove()
        {
            _flagMove = false;
        }

        public void StopMove()
        {
            _flagMove = true;
        }

    }
}
