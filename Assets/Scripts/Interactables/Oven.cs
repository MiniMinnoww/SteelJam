using UnityEngine;

namespace Interactables
{
    public class Oven : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite offSprite;
        [SerializeField] private Sprite onSprite;

        public static bool IsOn { get; private set; } = false;
        public static Oven Instance { get; private set; }

        private void Awake() => Instance = this;

        public static void Switch()
        {
            IsOn = !IsOn;
        }
    }
}