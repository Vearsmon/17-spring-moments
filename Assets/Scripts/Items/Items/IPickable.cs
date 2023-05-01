using Items.PickDetector;

namespace Items
{
    public interface IPickable
    {
        public IPickDetector PickDetector { get; }
    }
}