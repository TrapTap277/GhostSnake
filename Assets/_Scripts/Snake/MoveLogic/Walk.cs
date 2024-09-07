namespace _Scripts.Snake.MoveLogic
{
    public class Walk : BaseSnakeMove
    {
        private const float MOVE_SPEED = 40f;

        public Walk(SnakeConfig context) : base(context)
        {
            MoveSpeed = MOVE_SPEED;
        }
    }
}