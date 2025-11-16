using Player;
using UnityEngine;

namespace Interactables
{
    public class OvenButton : WorldInteractable
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite offSprite;
        [SerializeField] private Sprite onSprite;
        
        [SerializeField] private SpriteRenderer outlineRenderer;
        [SerializeField] private Sprite offOutline;
        [SerializeField] private Sprite onOutline;
        public override void OnPlayerInteract(PlayerInteractor interactor)
        {
            Oven.Switch();
            spriteRenderer.sprite = Oven.IsOn ? onSprite : offSprite;
            outlineRenderer.sprite = Oven.IsOn ? onOutline : offOutline;
        }
    }
}