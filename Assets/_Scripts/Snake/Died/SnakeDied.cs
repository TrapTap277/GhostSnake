using System;
using _Scripts.Music;
using _Scripts.Snake.Body;
using _Scripts.Snake.Eat;
using _Scripts.Snake.MoveLogic;
using Zenject;

namespace _Scripts.Snake.Died
{
    public class SnakeDied : IInitializable, IDisposable
    {
        private readonly BaseSnakeMove _snakeMove;
        private readonly DieUI _dieUI;
        private readonly SnakeBody _snakeBody;
        private readonly MusicSwitcher _musicSwitcher;

        public SnakeDied(BaseSnakeMove snakeMove, DieUI dieUI, SnakeBody snakeBody, MusicSwitcher musicSwitcher)
        {
            _musicSwitcher = musicSwitcher;
            _snakeBody = snakeBody;
            _dieUI = dieUI;
            _snakeMove = snakeMove;
        }

        public void Died()
        {
            _snakeMove.SetSnakeState(SnakeState.Died);
            _dieUI.ShowDieUI();
            _musicSwitcher.Switch(MusicCType.Defeat);
            _snakeBody.Reset();
        }
        
        public void Initialize()
        {
            SnakeCollisionDetector.OnDied += Died;
        }

        public void Dispose()
        {
            SnakeCollisionDetector.OnDied -= Died;
        }
    }
}