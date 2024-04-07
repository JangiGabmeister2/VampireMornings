using UnityEngine;

[RequireComponent(typeof(WithinLight))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 8f;

    private bool _facingRight = false;

    Rigidbody _rb => GetComponent<Rigidbody>();
    WithinLight _inLight => GetComponent<WithinLight>();

    float horizontal => Input.GetAxisRaw("Horizontal");
    float vertical => Input.GetAxisRaw("Vertical");

    private void Update()
    {
        Vector3 moveDir = transform.right * horizontal + transform.forward * vertical;
        moveDir *= _moveSpeed * Time.deltaTime;

        _rb.velocity = moveDir;

        if (_inLight.isWithinLight)
        {
            Debug.Log("You are within the light. *pretend you are getting hurt*");
        }

        if (_facingRight && horizontal < 0f || !_facingRight && horizontal > 0f)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
