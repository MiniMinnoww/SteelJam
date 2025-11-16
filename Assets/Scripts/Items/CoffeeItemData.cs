using System.Collections;
using UnityEngine;
using Player;

namespace Items
{
    [CreateAssetMenu(menuName="Game/Coffee Item")]
    public class CoffeeItemData : ItemData
    {
        public override void OnInteractInHand()
        {
            Player.Player.Instance.StartCoroutine(Activate());
        }

        private IEnumerator Activate()
        {
            SoundManager.PlaySoundEffect(SoundEffectType.PlayerCoffee);
            Player.Player.Interactor.Consume();
            Player.Player.Rigidbody.linearDamping = 2;
            yield return new WaitForSeconds(5);
            Player.Player.Rigidbody.linearDamping = 5;
            
            
        }
    }
}