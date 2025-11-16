using Unity.Cinemachine;
using UnityEngine;

public class RandomCameraWobble : MonoBehaviour
{
    [SerializeField] private CinemachineBasicMultiChannelPerlin noise;

    private void Update()
    {
        noise.AmplitudeGain = Mathf.Max(Mathf.Sin(Time.time), 0.1f) / 2;
    }
}
