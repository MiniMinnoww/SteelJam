using System;
using UnityEngine;

namespace Managers
{
    public class ManagerLoader : MonoBehaviour
    {
        private static bool managersLoaded = false;
        [SerializeField] private GameObject managersPrefab;

        private void Awake()
        {
            if (managersLoaded) return;
            
            GameObject managers = Instantiate(managersPrefab);
            DontDestroyOnLoad(managers);
            managersLoaded = true;
        }
    }
}
