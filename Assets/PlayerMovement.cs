using UnityEngine;

[RequireComponent(typeof(WithinLight))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 8f;

    Rigidbody2D _rb => GetComponent<Rigidbody2D>();
    WithinLight _inLight => GetComponent<WithinLight>();

    float horizontal => Input.GetAxisRaw("Horizontal");
    float vertical => Input.GetAxisRaw("Vertical");

    private void Update()
    {
        Vector3 moveDir = transform.right * horizontal + transform.up * vertical;
        moveDir *= _moveSpeed * Time.deltaTime;

        _rb.velocity = moveDir;

        if (_inLight.isWithinLight)
        {
            Debug.Log("You are within the light. *pretend you are getting hurt*");
        }
    }
}
