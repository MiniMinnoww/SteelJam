using System;
using Items;
using NUnit.Framework;
using Player;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Interactables
{
    public class Heating : WorldInteractable
    {
        [SerializeField] private ItemData requiredItem;
        [SerializeField] private Sprite brokenSprite;
        [SerializeField] private Sprite fixedSprite;
        
        [SerializeField] private Sprite brokenOutline;
        [SerializeField] private Sprite fixedOutline;

        [SerializeField] private Light2D heaterLight;
        
        [SerializeField] private SpriteRenderer spriteRenderer;
		public static bool IsOn {get; private set;}
        public override bool CanBeInteractedBy(PlayerInteractor interactor) => interactor.CurrentItem == requiredItem;

        private void Start()
        {
            IsOn = false;
        }

        public override void OnPlayerInteract(PlayerInteractor interactor)
        {
            if (interactor.CurrentItem == requiredItem)
            {
                IsOn = !IsOn;
                heaterLight.enabled = IsOn;
                interactor.Consume();
                SoundManager.PlaySoundEffect(SoundEffectType.FixHeat);   
            }
                
            

            spriteRenderer.sprite = IsOn ? fixedSprite : brokenSprite;
        }

        private void Update()
        {
            outline.sprite = IsOn ? fixedOutline : brokenOutline;
        }
    }
}