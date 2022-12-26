using System.Collections;
using System.Collections.Generic;
using Proje2.Abstracts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace  Proje2.Inputs
{
    public class InputReader : IInputReader
    {
        private PlayerInput _playerInput;
        public float Horizontal { get; private set; }
        public bool IsJump { get; private set; }

        public InputReader(PlayerInput playerInput)
        {
            _playerInput = playerInput;

            _playerInput.currentActionMap.actions[0].performed += OnHorizontalMover;
            _playerInput.currentActionMap.actions[1].started += OnJump;
            _playerInput.currentActionMap.actions[1].canceled += OnJump;
        }

        private void OnJump(InputAction.CallbackContext obj)
        {
            IsJump = obj.ReadValueAsButton();
        }

        private void OnHorizontalMover(InputAction.CallbackContext obj)
        {
            Horizontal = obj.ReadValue<float>();
        }
    }
}

