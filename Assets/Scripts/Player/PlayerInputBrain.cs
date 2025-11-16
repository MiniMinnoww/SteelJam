using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerInputBrain : MonoBehaviour
    {
        [SerializeField] private PlayerInput input;
        public event Action OnJumpEvent;
        public event Action OnInteractEvent;
        public event Action OnDropEvent;

        public float Horizontal => Mathf.Clamp(input.actions["Movement"].ReadValue<Vector2>().x, -1, 1);

        private void Start()
        {
            input.actions["Jump"].performed += OnJump;
            input.actions["Interact"].performed += OnInteract;
            input.actions["Drop"].performed += OnDrop;
        }

        private void OnJump(InputAction.CallbackContext ctx) => OnJumpEvent?.Invoke();
        private void OnInteract(InputAction.CallbackContext ctx) => OnInteractEvent?.Invoke();
        private void OnDrop(InputAction.CallbackContext ctx) => OnDropEvent?.Invoke();

        private void OnDisable()
        {
            input.actions["Jump"].performed -= OnJump;
            input.actions["Interact"].performed -= OnInteract;
            input.actions["Drop"].performed -= OnDrop;
        }
    }
}