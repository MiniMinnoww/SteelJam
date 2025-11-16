using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    public class SceneChangeManager : MonoBehaviour
    {
        private static SceneChangeManager Instance { get; set; }
        
        [SerializeField] private Image overlay;
        [SerializeField] private float fadeOutDuration = 0.5f;
        [SerializeField] private float fadeInDuration = 0.25f;
        private Coroutine switchSceneRoutine;

        private void Awake() => Instance = this;

        private void Start()
        {
            overlay.color = new Color(0, 0, 0, 0);
            overlay.gameObject.SetActive(false);
        }

        public static void SwitchScene(string scene)
        {
            if (Instance.switchSceneRoutine != null) Instance.StopCoroutine(Instance.switchSceneRoutine);
            Instance.switchSceneRoutine = Instance.StartCoroutine(Instance.SwitchSceneCoroutine(scene));
        }

        private IEnumerator SwitchSceneCoroutine(string scene)
        {
            overlay.gameObject.SetActive(true);
            overlay.DOFade(1, fadeOutDuration);
            yield return new WaitForSeconds(fadeOutDuration);

            yield return SceneManager.LoadSceneAsync(scene);

            overlay.DOFade(0, fadeInDuration).OnComplete(() => overlay.gameObject.SetActive(false));
        }
    }
}