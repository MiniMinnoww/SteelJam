using UnityEngine;

[DefaultExecutionOrder(1000)]
public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private float parallaxStrength = 0.5f;
    private Vector3 lastCameraPos;
    [SerializeField] private float moveSpeed;
    

    private void Start()
    {
        lastCameraPos = Camera.main.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 camPos = Camera.main.transform.position;
        Vector3 delta = camPos - lastCameraPos;

        transform.position += (delta * parallaxStrength) + (Vector3)(Vector2.right * (moveSpeed * Time.deltaTime));

        lastCameraPos = camPos;
    }
}
