using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveForce;
        [SerializeField] private float jumpForce;
        [SerializeField] private GroundedData groundedData;

        private bool Grounded => Physics2D.OverlapCircle(groundedData.groundedPosition.position, groundedData.detectRadius,
            groundedData.groundLayers) != null;

        private void Start()
        {
            Player.Input.OnJumpEvent += OnJump;
        }

        private void FixedUpdate()
        {
            Player.Rigidbody.AddForceX(Player.Input.Horizontal * moveForce);
        }

        private void OnJump()
        {
            if (!Grounded) return;
            
            // Jump logic here
            Player.Rigidbody.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }
    
    [Serializable]
    public struct GroundedData
    {
        public Transform groundedPosition;
        public float detectRadius;
        public LayerMask groundLayers;
    }
}