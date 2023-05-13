using Items.ClickDetector;

namespace Items.Items
{
    public interface IClickable
    {
        public IClickDetector ClickDetector { get; }
    }
}