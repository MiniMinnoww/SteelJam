using UnityEngine;

public class Train : MonoBehaviour
{
    public static Train Instance {get; private set;}
    
    [SerializeField] private float speed;
    
    private void Awake() => Instance = this;
    
    
    private void Update()
    {
        transform.Translate( Vector2.right * (speed * Time.deltaTime));
    }
}
