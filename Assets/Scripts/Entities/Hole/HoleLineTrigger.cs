using _3rdParty.git_amend.EventBus;
using UnityEngine;

namespace Entities.Hole
{
    public class HoleLineTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                EventBus<FinishLineTriggeredEvent>.Raise(new FinishLineTriggeredEvent());
            }
        }
    }
}


