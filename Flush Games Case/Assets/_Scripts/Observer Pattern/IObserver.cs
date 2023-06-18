using StackGame.Player;

namespace StackGame.Observer_Pattern
{
    public interface IObserver
    {
        public void OnNotify(PlayerMovement movement);
    }
}
