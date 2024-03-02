using Entities.Collectible;

namespace Entities.Hole
{
    public class HoleItemCollector : Collector<ICollectible>
    {
        private void OnEnable()
        {
            OnCollectibleAdded += OnItemCollected;
        }

        private void OnItemCollected(ICollectible item)
        {
            item.Explode(2f);
        }
    }
}