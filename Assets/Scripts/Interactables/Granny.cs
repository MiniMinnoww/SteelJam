using Player;
using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace Interactables
{
    public class Granny : WorldInteractable
    {
        [SerializeField] private Transform grannyText1;
        [SerializeField] private Transform grannyText2;

        private const float SHOW_DURATION = 2f;       // how long text stays visible
        private const float POP_DURATION = 0.25f;      // pop in/out speed

        private bool isShowing; // spam prevention

        private void Awake()
        {
            // Ensure both are hidden on start
            grannyText1.localScale = Vector3.zero;
            grannyText2.localScale = Vector3.zero;

            grannyText1.gameObject.SetActive(false);
            grannyText2.gameObject.SetActive(false);
        }

        public override void OnPlayerInteract(PlayerInteractor interactor)
        {
            if (isShowing) return; // prevent spam

            Transform textToShow = Heating.IsOn ? grannyText2 : grannyText1;
            StartCoroutine(ShowTextRoutine(textToShow));
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