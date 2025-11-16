using System.Collections;
using System.Globalization;
using DG.Tweening;
using Managers;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class DeathScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI youDiedText;
        [SerializeField] private Rigidbody2D playerRb;
        [SerializeField] private Vector2 forceToAdd;
        
        private IEnumerator Start()
        {
            // Make "you scored" rise up from its OG position minus 5 on the Y axis, and
            Vector2 ogPos = youDiedText.rectTransform.anchoredPosition;
            Color ogCol = youDiedText.color;
    
            ogCol.a = 0;
            youDiedText.color = ogCol;
    
            yield return new WaitForSeconds(1);

            SoundManager.PlaySoundEffect(SoundEffectType.PlayerLose);

            playerRb.bodyType = RigidbodyType2D.Dynamic;
            playerRb.AddForce(forceToAdd, ForceMode2D.Impulse);
            
            youDiedText.rectTransform.anchoredPosition += Vector2.down;
            youDiedText.rectTransform.DOAnchorPosY(ogPos.y, 0.5f);
    
            youDiedText.DOFade(1, 0.5f);
            
            yield return new WaitForSeconds(4f);
            
            SceneChangeManager.SwitchScene("MainLevel");
        }
    }
}