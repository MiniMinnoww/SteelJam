using Player;
using UnityEngine;

namespace Interactables
{
    public abstract class WorldInteractable : MonoBehaviour
    {
        public abstract void OnPlayerInteract(PlayerInteractor interactor);

        public virtual void ShowInteractEffect()
        {
            // Not really sure what to do here?
            // Need a popup
            if (TryGetComponent(out SpriteRenderer sr)) sr.color = Color.red;
        }

        public virtual void HideInteractEffect()
        {
            if (TryGetComponent(out SpriteRenderer sr)) sr.color = Color.white;
        }
    }
}