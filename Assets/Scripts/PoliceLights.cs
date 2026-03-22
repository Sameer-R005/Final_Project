using UnityEngine;

public class PoliceLights : MonoBehaviour
{
    public Light redLight;
    public Light blueLight;

    public float flashSpeed = 0.3f;

    void Start()
    {
        InvokeRepeating("FlashLights", 0, flashSpeed);
    }

    void FlashLights()
    {
        redLight.enabled = !redLight.enabled;
        blueLight.enabled = !blueLight.enabled;
    }
}
