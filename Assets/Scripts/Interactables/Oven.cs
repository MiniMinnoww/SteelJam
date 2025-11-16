using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Interactables
{
    public class Oven : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite offSprite;
        [SerializeField] private Sprite onSprite;
        [SerializeField] private Light2D ovenLight;

        public static bool IsOn { get; private set; } = false;
        public static Oven Instance { get; private set; }

        private void Awake() => Instance = this;

        private void Start()
        {
            IsOn = false;
        }

        public static void Switch()
        {
            IsOn = !IsOn;

            Instance.ovenLight.enabled = IsOn;

            Instance.spriteRenderer.sprite = IsOn ? Instance.onSprite : Instance.offSprite;
        }
    }
}