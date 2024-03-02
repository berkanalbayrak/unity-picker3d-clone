using UnityEngine;

namespace Core.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform followTargetTransform;

        private Vector3 _offset;

        private void Awake()
        {
            _offset = followTargetTransform.position - transform.position;
        }

        private void LateUpdate()
        {
            transform.position = new Vector3(0, followTargetTransform.position.y - _offset.y, followTargetTransform.position.z - _offset.z);
        }
    }
}
