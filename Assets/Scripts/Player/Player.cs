using System;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public static Player Instance {get; private set;}

        [SerializeField] private PlayerMovement movement;
        [SerializeField] private PlayerInputBrain input;
        [SerializeField] private Rigidbody2D rb;

        public static PlayerMovement Movement => Instance.movement;
        public static PlayerInputBrain Input => Instance.input;
        public static Rigidbody2D Rigidbody => Instance.rb;
        public static Transform Transform => Instance.transform;
        public static PlayerInteractor Interactor { get; private set; }

        private void Awake() => Instance = this;

        private void Start()
        {
            Interactor = GetComponent<PlayerInteractor>();
        }
    }
}