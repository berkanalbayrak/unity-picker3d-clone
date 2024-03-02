using System;
using Entities.Collectible;
using TMPro;
using UnityEngine;

namespace Entities.Hole
{
    public class Hole : MonoBehaviour
    {
        [SerializeField] private int levelCollectibleTarget;
        [SerializeField] private HoleItemCollector holeItemCollector;
        
        [SerializeField] private TextMeshPro targetText;

        private int _currentCollectibleCount = 0;
        
        private void Start()
        {
            targetText.text = $"{_currentCollectibleCount}/{levelCollectibleTarget}";
        }

        private void OnEnable()
        {
            holeItemCollector.OnCollectibleAdded += OnItemCollected;
            holeItemCollector.OnCollectibleRemoved += OnItemRemoved;
        }

        private void OnDisable()
        {
            holeItemCollector.OnCollectibleRemoved -= OnItemCollected;
        }

        private void OnItemCollected(ICollectible collectible)
        {
            _currentCollectibleCount++;
            UpdateTargetText();
        }

        private void OnItemRemoved(ICollectible collectible)
        {
            _currentCollectibleCount--;
            UpdateTargetText();
        }

        private void UpdateTargetText()
        {
            targetText.text = $"{_currentCollectibleCount}/{levelCollectibleTarget}";
        }
    }
}
