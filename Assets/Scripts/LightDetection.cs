using UnityEngine;

public class LightDetection : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _light;
    [SerializeField] private Transform _lightDirection;

    private Ray lightRay = new Ray();

    private void Update()
    {
        lightRay = new Ray(_player.position, _lightDirection.position - _light.position);

        if (!Physics.Raycast(lightRay.origin, lightRay.direction * -100))
        {
            Debug.Log("You are within the light. *pretend you are getting hurt*");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (Physics.Raycast(lightRay.origin, lightRay.direction * -100))
        {
            Gizmos.color = Color.red;
        }

        Gizmos.DrawRay(lightRay.origin, lightRay.direction * -100);
    }
}
