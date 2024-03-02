using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Entities.Collectible
{
    public interface ICollectible
    {
        void Throw(Vector3 direction, Vector3 force, ForceMode forceMode = ForceMode.Force);
        UniTaskVoid Explode(float delay);
    }
}