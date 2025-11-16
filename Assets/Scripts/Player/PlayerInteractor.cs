using System;
using Interactables;
using Items;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// On the player. Handles the inventory and interacting
    /// </summary>
    public class PlayerInteractor : MonoBehaviour
    {
        [SerializeField] private float interactRadius;
        [SerializeField] private LayerMask interactLayers;
        [SerializeField] private SpriteRenderer itemDisplaySpriteRenderer;
        public ItemData CurrentItem { get; private set; }
        public bool HasItem => CurrentItem != null;

        private WorldInteractable lastHighlighted;
        private void Start()
        {
            Player.Input.OnInteractEvent += OnInteract;
            Player.Input.OnDropEvent += OnDrop;
        }

        private void Update()
        {
            if (TryGetInteractable(out WorldInteractable interactable))
            {
                if (interactable != lastHighlighted && lastHighlighted) lastHighlighted.HideInteractEffect();
                interactable.ShowInteractEffect();
                lastHighlighted = interactable;
            }
            else
            {
                lastHighlighted?.HideInteractEffect();
                lastHighlighted = null;
            }
        }

        private void OnInteract()
        {
            if (TryGetInteractable(out WorldInteractable interactable))
                interactable.OnPlayerInteract(this);
            
            else if (HasItem) CurrentItem.OnInteractInHand();
        }

        private void OnDrop()
        {
            if (!CurrentItem) return;
            
            itemDisplaySpriteRenderer.color = Color.clear;
            
            // Spawn in the item again
            Instantiate(CurrentItem.worldItemPrefab, transform.position, Quaternion.identity).OnDrop(CurrentItem);
            CurrentItem = null;
        }

        public void Consume()
        {
            if (!CurrentItem) return;

            itemDisplaySpriteRenderer.color = Color.clear;
            CurrentItem = null;
        }

        private bool TryGetInteractable(out WorldInteractable interactable)
        {
            interactable = null;

            Collider2D detectedObject = Physics2D.OverlapCircle(Player.Transform.position, interactRadius, interactLayers);
            return detectedObject && detectedObject.TryGetComponent(out interactable);
        }

        public void GiveItem(ItemData data)
        {
            if (!HasItem) CurrentItem = data;

            itemDisplaySpriteRenderer.sprite = CurrentItem.itemSprite;
            itemDisplaySpriteRenderer.color = Color.white;
        }
    }
}