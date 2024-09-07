namespace _Scripts.Snake.MoveLogic
{
    public class Run : BaseSnakeMove
    {
        private const float MOVE_SPEED = 60;

        public Run(SnakeConfig context) : base(context)
        {
            MoveSpeed = MOVE_SPEED;
        }
    }
}