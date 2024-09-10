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
        private readonly AliveUI _aliveUI;
        private MusicType _type;

        public SnakeDied(DieUI dieUI, BaseSnakeMove snakeMove, SnakeBody snakeBody, MusicSwitcher musicSwitcher,
            AliveUI aliveUI)
        {
            _aliveUI = aliveUI;
            _musicSwitcher = musicSwitcher;
            _snakeBody = snakeBody;
            _dieUI = dieUI;
            _snakeMove = snakeMove;
        }

        private void Died()
        {
            _snakeMove.SetSnakeState(SnakeState.Died);
            _dieUI.ShowUI();
            _aliveUI.FadeAliveUI();
            _musicSwitcher.Switch();
            _snakeBody.Reset();
        }

        public void Initialize()
        {
            SnakeCollisionDetector.OnSnakeDied += Died;
        }

        public void Dispose()
        {
            SnakeCollisionDetector.OnSnakeDied -= Died;
        }
    }
}