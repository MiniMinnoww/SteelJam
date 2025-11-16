using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Interactables
{
    public class Billows : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        [SerializeField] private Vector2 colliderTargetOffsetGround;
        [SerializeField] private Vector2 colliderTargetSizeGround;
        [SerializeField] private Vector2 colliderTargetOffsetAir;
        [SerializeField] private Vector2 colliderTargetSizeAir;

        [SerializeField] private Sprite[] sprites;

        [SerializeField] private BoxCollider2D boxCollider;

        [SerializeField] private float timeBetweenFrames;
        
        private const float TIME_DOWN = 1;
        private const float TIME_UP = 1;

        private void Start()
        {
            StartCoroutine(MoveRoutine());
        }

        private IEnumerator MoveRoutine()
        {
            while (true)
            {
                if (!Oven.IsOn) 
                {
                    yield return null; 
                    continue;
                }
                
                spriteRenderer.sprite = sprites[0];

                // Wait before movement starts
                yield return new WaitForSeconds(TIME_DOWN);

                // Move up
                DOTween.To(() => boxCollider.size, 
                    x => boxCollider.size = x, 
                    colliderTargetSizeAir, 
                    timeBetweenFrames * 5);

                DOTween.To(() => boxCollider.offset, 
                    x => boxCollider.offset = x, 
                    colliderTargetOffsetAir, 
                    timeBetweenFrames * 5);

                SoundManager.PlaySoundEffect(SoundEffectType.BillowUp);

                for (int n = 0; n < 5; n++)
                {
                    spriteRenderer.sprite = sprites[n];
                    yield return new WaitForSeconds(timeBetweenFrames);
                }

                // Wait at top
                boxCollider.size = colliderTargetSizeAir;
                boxCollider.offset = colliderTargetOffsetAir;
                spriteRenderer.sprite = sprites[4];
                yield return new WaitForSeconds(TIME_UP);

                // === Move Down ===
                DOTween.To(() => boxCollider.size, 
                    x => boxCollider.size = x, 
                    colliderTargetSizeGround, 
                    timeBetweenFrames * 5);

                DOTween.To(() => boxCollider.offset, 
                    x => boxCollider.offset = x, 
                    colliderTargetOffsetGround, 
                    timeBetweenFrames * 5);

                SoundManager.PlaySoundEffect(SoundEffectType.BillowDown);

                for (int n = 4; n >= 0; n--)
                {
                    spriteRenderer.sprite = sprites[n];
                    yield return new WaitForSeconds(timeBetweenFrames);
                }

                boxCollider.size = colliderTargetSizeGround;
                boxCollider.offset = colliderTargetOffsetGround;
            }
        }

    }
}