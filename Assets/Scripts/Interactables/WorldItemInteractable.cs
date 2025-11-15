using System;
using Items;
using Player;
using UnityEngine;

namespace Interactables
{
    /// <summary>
    /// A class for world items (items that exist in the game world that can be picked up
    /// </summary>
    public class WorldItemInteractable : WorldInteractable
    {
        [SerializeField] private ItemData item;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Rigidbody2D rb;

        private void Start()
        {
            spriteRenderer.sprite = item.itemSprite;
        }

        public void OnDrop(ItemData item)
        {
            this.item = item;
            spriteRenderer.sprite = item.itemSprite;
            
            // called when a player drops us after we spawn
            rb.linearVelocity = Player.Player.Rigidbody.linearVelocity;
        }

        public override void OnPlayerInteract(PlayerInteractor interactor)
        {
            if (interactor.HasItem) return;

            interactor.GiveItem(item);
            Destroy(gameObject);
        }
    }
}