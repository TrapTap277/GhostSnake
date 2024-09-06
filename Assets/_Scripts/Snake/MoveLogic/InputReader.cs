using System;
using UnityEngine;
using Zenject;

namespace _Scripts.Snake.MoveLogic
{
    public class InputReader : IInitializable, ITickable, IDisposable
    {
        private SnakeInput _playerInput;

        private MoveCommand _moveCommand;

        private IMove _currentMoveBehaviour;

        private IMove _shiftingBehaviour;
        private IMove _walkBehaviour;
        private IMove _runBehaviour;

        private bool _isShifting;
        private bool _isRunning;

        private Vector2 _moveDirection;

        [Inject]
        private void Construct([Inject(Id = "Shifting")] IMove shiftingPlayer, [Inject(Id = "Move")] IMove movePlayer,
            [Inject(Id = "Run")] IMove runPlayer)
        {
            _shiftingBehaviour = shiftingPlayer;
            _walkBehaviour = movePlayer;
            _runBehaviour = runPlayer;

            _playerInput = new SnakeInput();

            _moveCommand = new MoveCommand();
        }

        public void Initialize()
        {
            _playerInput.Enable();

            InitInputs();
        }

        public void Tick()
        {
            if (_currentMoveBehaviour != null) ExecuteMove();

            if (_isRunning)
                ChangeMoveBehaviour(_runBehaviour);
            else if (_isShifting)
                ChangeMoveBehaviour(_shiftingBehaviour);
            else
                ChangeMoveBehaviour(_walkBehaviour);
        }

        private void ExecuteMove()
        {
            _moveCommand.Execute(_currentMoveBehaviour, _moveDirection);
        }

        private void SetShifting(bool shiftingState)
        {
            _isShifting = shiftingState;

            if (shiftingState)
                ChangeMoveBehaviour(_shiftingBehaviour);
            else if (!_isRunning) ChangeMoveBehaviour(_walkBehaviour);
        }

        private void SetRun(bool runState)
        {
            _isRunning = runState;

            if (runState)
                ChangeMoveBehaviour(_runBehaviour);
            else if (!_isShifting) ChangeMoveBehaviour(_walkBehaviour);
        }

        private void ChangeMoveBehaviour(IMove moveBehaviour)
        {
            _currentMoveBehaviour = moveBehaviour;
        }

        private void ChangeIsMoving(bool isMove, Vector2 direction)
        {
            if (isMove)
            {
                _moveDirection = direction;
            }
            else
            {
                if (!_isShifting && !_isRunning) _moveDirection = Vector2.zero;
            }
        }

        private void InitInputs()
        {
            _playerInput.Main.Move.performed += context => ChangeIsMoving(true, context.ReadValue<Vector2>());
            _playerInput.Main.Shifting.performed += context => SetShifting(true);
            _playerInput.Main.Shifting.canceled += context => SetShifting(false);
            _playerInput.Main.Run.performed += context => SetRun(true);
            _playerInput.Main.Run.canceled += context => SetRun(false);
        }

        public void Dispose()
        {
            _playerInput.Disable();
        }
    }
}