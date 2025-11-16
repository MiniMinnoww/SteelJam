using Items;
using Managers;
using Player;
using UnityEngine;

namespace Interactables
{
    public class Window : WorldInteractable
    {
        [SerializeField] private ItemData requiredItem;
        public override void OnPlayerInteract(PlayerInteractor interactor)
        {
            // Win or lose
            SceneChangeManager.SwitchScene(interactor.CurrentItem == requiredItem ? "PlayerWin" : "PlayerLose");
        }
    }
}
