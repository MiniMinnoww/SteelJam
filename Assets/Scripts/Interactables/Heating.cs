using Items;
using Player;
using UnityEngine;

namespace Interactables
{
    public class Heating : WorldInteractable
    {
        [SerializeField] private ItemData requiredItem;
        [SerializeField] private Sprite brokenSprite;
        [SerializeField] private Sprite fixedSprite;
        [SerializeField] private SpriteRenderer spriteRenderer;
		public static bool IsOn {get; private set;}
        public override void OnPlayerInteract(PlayerInteractor interactor)
        {
            if (interactor.CurrentItem == requiredItem)
                IsOn = !IsOn;

            spriteRenderer.sprite = IsOn ? fixedSprite : brokenSprite;
        }
    }
}