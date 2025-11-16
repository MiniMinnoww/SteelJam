using System;
using Managers;
using UnityEngine;
using Util;

public class DeathArea : MonoBehaviour
{
    [SerializeField] private LayerMask trainCollisionLayer;
    /// <summary>
    /// Called when the train passes through
    /// </summary>
    /// <param name="other">The collider</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Utils.IsMaskInLayer(trainCollisionLayer, other.gameObject.layer))
        {
            SceneChangeManager.SwitchScene("TrainDeath");
        }
    }
}
