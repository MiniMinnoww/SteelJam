using Player;
using UnityEngine;

namespace Interactables
{
    public abstract class WorldInteractable : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer outline;
        public abstract void OnPlayerInteract(PlayerInteractor interactor);
        public virtual bool CanBeInteractedBy(PlayerInteractor interactor) => !interactor.CurrentItem;

        public virtual void ShowInteractEffect()
        {
            outline.enabled = true;
        }

        public virtual void HideInteractEffect()
        {
            outline.enabled = false;
        }
    }
}