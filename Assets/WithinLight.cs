using UnityEngine;

public class WithinLight : MonoBehaviour
{
    public bool isWithinLight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            isWithinLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            isWithinLight = false;
        }
    }
}
