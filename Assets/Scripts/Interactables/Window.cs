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
            if (interactor.CurrentItem == requiredItem)
            {
                GameManager.Instance.WinLevel();
            }
            else WinScreenManager.actualScore = 0;
            SceneChangeManager.SwitchScene(interactor.CurrentItem == requiredItem ? "PlayerWin" : "PlayerLose");
        }
    }
}
