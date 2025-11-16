using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName="Game/Horn Item")]
    public class HornItemData : ItemData
    {
        public override void OnInteractInHand()
        {
            SoundManager.PlaySoundEffect(SoundEffectType.ClownHorn);
        }
    }
}