using UnityEngine;
using UnityEngine.Animations;
namespace Player
{
    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private Animator controller;

        private void Update()
        {
            controller.SetFloat("vel", Mathf.Abs(Player.Input.Horizontal));

            Player.Transform.localScale = Player.Rigidbody.linearVelocity.x switch
            {
                > 0.1f => new Vector3(-1, 1, 1),
                < -0.1f => new Vector3(1, 1, 1),
                _ => Player.Transform.localScale
            };
        }
    }
}
