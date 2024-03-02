using _3rdParty.git_amend.EventBus;
using Entities.Collectible;
using UnityEngine;

namespace Entities.Picker
{
    public class PickerItemCollector : Collector<ICollectible>
    {
        [SerializeField] private float throwForceMin;
        [SerializeField] private float throwForceMax;
        
        private EventBinding<FinishLineTriggeredEvent> _finishLineTriggerBinding;
        
        private void OnEnable()
        {
            _finishLineTriggerBinding = new EventBinding<FinishLineTriggeredEvent>(OnFinishLineTriggered);
            EventBus<FinishLineTriggeredEvent>.Register(_finishLineTriggerBinding);
        }
        
        private void OnDisable()
        {
            EventBus<FinishLineTriggeredEvent>.Deregister(_finishLineTriggerBinding);
        }
        
        private void OnFinishLineTriggered(FinishLineTriggeredEvent @event)
        {
            ThrowCollectedItems();
        }
        
        private void ThrowCollectedItems()
        {
            foreach (var item in collectedObjects)
            {
                var randomThrowForceFactor = Random.Range(throwForceMin, throwForceMax);
                var throwDirection = transform.forward + transform.up;
                item.Throw(throwDirection, throwDirection * randomThrowForceFactor, ForceMode.Impulse);
            }
        }

    }
}