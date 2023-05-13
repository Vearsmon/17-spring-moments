using Items.InteractionDetector;

namespace Items.Items
{
    public interface IInteractive
    {
        public IInteractionDetector InteractionDetector { get; }
    }
}