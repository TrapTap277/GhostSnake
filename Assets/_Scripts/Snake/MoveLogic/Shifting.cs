namespace _Scripts.Snake.MoveLogic
{
    public class Shifting : BaseSnakeMove
    {
        private const float MOVE_SPEED = 20;

        public Shifting(SnakeConfig context) : base(context)
        {
            MoveSpeed = MOVE_SPEED;
        }
    }
}