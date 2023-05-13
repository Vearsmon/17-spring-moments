using Items.PickDetector;

namespace Items
{
    public interface IInteractive
    {
        public IInteractionDetector InteractionDetector { get; }
    }
}