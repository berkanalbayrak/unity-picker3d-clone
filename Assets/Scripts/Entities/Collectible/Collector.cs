using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Collectible
{
    public class Collector<T> : MonoBehaviour where T : ICollectible
    {
        public IReadOnlyCollection<T> CollectedObjects => collectedObjects;
        
        protected readonly HashSet<T> collectedObjects = new HashSet<T>();
        
        public Action<T> OnCollectibleAdded;
        public Action<T> OnCollectibleRemoved;
        
        protected virtual void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Collectible"))
                return;
            
            if (other.TryGetComponent<T>(out var collectible))
            {
                collectedObjects.Add(collectible);
                OnCollectibleAdded?.Invoke(collectible);
            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if(!other.CompareTag("Collectible"))
                return;
            
            if (other.TryGetComponent<T>(out var collectible))
            {
                collectedObjects.Remove(collectible);
                OnCollectibleRemoved?.Invoke(collectible);
            }
        }
        
    }
}