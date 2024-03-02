using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Entities.Collectible
{
    public class Collectible : MonoBehaviour, ICollectible
    {
        [SerializeField] private Rigidbody rb;       
        
        public void Throw(Vector3 direction, Vector3 force, ForceMode forceMode = ForceMode.Force)
        {
            rb.AddForceAtPosition(force, direction, forceMode);
        }

        public async UniTaskVoid Explode(float delay)
        {
            await UniTask.Delay((int) (delay * 1000));
            Destroy(gameObject);
        }
    }
}