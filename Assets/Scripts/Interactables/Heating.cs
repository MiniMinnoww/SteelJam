using Items;
using Player;
using UnityEngine;

namespace Interactables
{
    public class Heating : WorldInteractable
    {
        [SerializeField] private ItemData requiredItem;
		public static bool IsOn {get; private set;}
        public override void OnPlayerInteract(PlayerInteractor interactor)
        {
            if (interactor.CurrentItem == requiredItem)
                IsOn = !IsOn;
        }
    }
}