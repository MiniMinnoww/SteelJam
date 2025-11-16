using Managers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler
{
    [SerializeField] private string scene;

    private bool isSelected;
    [SerializeField] private float rotateAmount = 5;
    [SerializeField] private float rotateSpeed = 5;
    [SerializeField] private EventSystem eventSystem;
    private Quaternion originalRotation;

    private void Start()
    {
        originalRotation = transform.rotation;
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void Update()
    {
        if (!isSelected) return;
        float angle = Mathf.Sin(Time.time * rotateSpeed) * rotateAmount;
        transform.rotation = originalRotation * Quaternion.Euler(0, 0, angle);
    }

    public void OnSelect(BaseEventData eventData)
    {
        isSelected = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
        transform.rotation = originalRotation;
    }

    private void OnClick()
    {
        if (scene == "") return;
        SceneChangeManager.SwitchScene(scene);
        GetComponent<Button>().interactable = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventSystem.SetSelectedGameObject(gameObject);
        OnSelect(null);
    }
}