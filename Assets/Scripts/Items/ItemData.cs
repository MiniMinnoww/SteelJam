using Interactables;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName="Game/Item")]
    public class ItemData : ScriptableObject
    {
        public WorldItemInteractable worldItemPrefab;
		public Sprite itemSprite;
    }
}