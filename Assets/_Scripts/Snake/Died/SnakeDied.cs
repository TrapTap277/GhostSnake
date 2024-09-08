using _Scripts.Music;
using _Scripts.Snake.Body;
using _Scripts.Snake.MoveLogic;

namespace _Scripts.Snake.Died
{
    public class SnakeDied
    {
        private readonly BaseSnakeMove _snakeMove;
        private readonly DieUI _dieUI;
        private readonly SnakeBody _snakeBody;
        private readonly MusicSwitcher _musicSwitcher;
        private readonly AliveUI _aliveUI;

        public SnakeDied(BaseSnakeMove snakeMove, DieUI dieUI, SnakeBody snakeBody, MusicSwitcher musicSwitcher,
            AliveUI aliveUI)
        {
            _aliveUI = aliveUI;
            _musicSwitcher = musicSwitcher;
            _snakeBody = snakeBody;
            _dieUI = dieUI;
            _snakeMove = snakeMove;
        }

        public void Died()
        {
            _snakeMove.SetSnakeState(SnakeState.Died);
            _dieUI.ShowDieUI();
            _aliveUI.FadeAliveUI();
            _musicSwitcher.Switch(MusicCType.Defeat);
            _snakeBody.Reset();
        }
    }
}