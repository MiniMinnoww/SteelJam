using Player;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using Items;

namespace Interactables
{
    public class Granny : WorldInteractable
    {
        [SerializeField] private Transform grannyText1;
        [SerializeField] private Transform grannyText2;
        [SerializeField] private ItemData blanketItem;
        [SerializeField] private WorldItemInteractable worldItemPrefab;

        [SerializeField] private SpriteRenderer grannySprite;
        [SerializeField] private SpriteRenderer grannyOutline;
        
        [SerializeField] private Sprite hasBlanketSprite;
        [SerializeField] private Sprite noBlanketSprite;
        
        [SerializeField] private Sprite hasBlanketOutline;
        [SerializeField] private Sprite noBlanketOutline;

        private const float SHOW_DURATION = 2f;
        private const float POP_DURATION = 0.25f;

        private bool isShowing; // spam prevention

        private static bool HasBlanket { get; set; } = true;

        private void Awake()
        {
            // Ensure both are hidden on start
            grannyText1.localScale = Vector3.zero;
            grannyText2.localScale = Vector3.zero;

            grannyText1.gameObject.SetActive(false);
            grannyText2.gameObject.SetActive(false);

            HasBlanket = true;
        }

        public override void OnPlayerInteract(PlayerInteractor interactor)
        {
            if (isShowing) return; // Prevent spam

            SoundManager.PlaySoundEffect(SoundEffectType.GrannyInteract);

            Transform textToShow = Heating.IsOn ? grannyText2 : grannyText1;
            if (Heating.IsOn && HasBlanket)
            {
                // Give player the blanket
                Instantiate(worldItemPrefab, transform.position, Quaternion.identity).OnDrop(blanketItem);
                HasBlanket = false;
            }
            StartCoroutine(ShowTextRoutine(textToShow));

            grannySprite.sprite = HasBlanket ? hasBlanketSprite : noBlanketSprite;
            grannyOutline.sprite = HasBlanket ? hasBlanketOutline : noBlanketOutline;
        }

        private IEnumerator ShowTextRoutine(Transform text)
        {
            isShowing = true;
            
            text.gameObject.SetActive(true);
            text.localScale = Vector3.zero;
            
            text.DOScale(1f, POP_DURATION).SetEase(Ease.OutBack);
            
            yield return new WaitForSeconds(SHOW_DURATION);
            
            yield return text.DOScale(0f, POP_DURATION).SetEase(Ease.InBack).WaitForCompletion();
            
            text.gameObject.SetActive(false);

            isShowing = false;
        }
    }
}