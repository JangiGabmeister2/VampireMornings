using UnityEngine;

[ExecuteAlways]
public class EnableCamera : MonoBehaviour
{
    public bool playerInView = false; //if player is within borders of area
    public float size = 5;
    public Color cameraBackground = Color.black;

    [SerializeField] Vector3 _cameraBorders = new Vector3(16, 9, 30);
    private Vector3 _newBorders = Vector3.zero;

    private void OnValidate()
    {
        _newBorders = _cameraBorders * size;
        cameraBackground.a = 0;
    }

    //creates preview of camera outline when changing preferred size.
    private void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Vector3.zero, _newBorders);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
            playerInView = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
            playerInView = false;
    }
}