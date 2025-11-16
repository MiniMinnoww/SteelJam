using System;
using Items;
using NUnit.Framework;
using Player;
using UnityEngine;

namespace Interactables
{
    public class Heating : WorldInteractable
    {
        [SerializeField] private ItemData requiredItem;
        [SerializeField] private Sprite brokenSprite;
        [SerializeField] private Sprite fixedSprite;
        
        [SerializeField] private Sprite brokenOutline;
        [SerializeField] private Sprite fixedOutline;
        
        [SerializeField] private SpriteRenderer spriteRenderer;
		public static bool IsOn {get; private set;}
        public override void OnPlayerInteract(PlayerInteractor interactor)
        {
            if (interactor.CurrentItem == requiredItem)
                IsOn = !IsOn;

            spriteRenderer.sprite = IsOn ? fixedSprite : brokenSprite;
        }

        private void Update()
        {
            outline.sprite = IsOn ? fixedOutline : brokenOutline;
        }
    }
}