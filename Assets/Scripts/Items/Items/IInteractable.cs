using Items.InteractionDetector;

namespace Items.Items
{
    public interface IInteractable
    {
        public IInteractionDetector InteractionDetector { get; }
    }
}