using UnityEngine;

namespace Assets.Code.Gameplay.Logic
{
    public class MovingPlatform : MonoBehaviour, IMoving
    {
        [SerializeField]
        private float speed = 1f;

        [SerializeField]
        private Transform _pointA;

        [SerializeField]
        private Transform _pointB;

        public (Transform PointA, Transform PointB) GetPoints()
        {
            return (_pointA, _pointB);
        }

        private Vector3 _target;

        private void Start()
        {
            _target = _pointB.position;
        }

        private void Update()
        {
            Vector3 previousPosition = transform.position;

            transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);

            if (HasPassedTarget(previousPosition, _target))
            {
                _target = _target == _pointA.position ? _pointB.position : _pointA.position;
            }
        }

        private bool HasPassedTarget(Vector3 currentPosition, Vector3 target)
        {
            Vector3 toTarget = target - currentPosition;
            Vector3 toNext = target - transform.position;

            return Vector3.Dot(toTarget.normalized, toNext.normalized) == 0;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<MoverX>() == null)
                return;

            other.transform.SetParent(transform);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<MoverX>() == null)
                return;

            if (!gameObject.activeInHierarchy)
                return;

            other.transform.SetParent(null);
        }
    }
}