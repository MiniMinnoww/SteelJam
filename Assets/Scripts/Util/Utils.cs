using UnityEngine;

namespace Util
{
    public static class Utils
    {
        public static bool IsMaskInLayer(LayerMask mask, int layer)
        {
            return (mask & (1 << layer)) != 0;
        }
    }
}