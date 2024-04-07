using UnityEngine;

public class WithinLight : MonoBehaviour
{
    public bool isWithinLight;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            isWithinLight = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            isWithinLight = false;
        }
    }
}
