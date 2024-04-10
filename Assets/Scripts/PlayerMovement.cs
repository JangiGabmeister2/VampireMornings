using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] Transform playerSprite;

    private bool _facingRight = false;
    private Vector3 _moveDirection = Vector3.zero;

    Rigidbody _rb => GetComponent<Rigidbody>();

    float horizontal => Input.GetAxisRaw("Horizontal");
    float vertical => Input.GetAxisRaw("Vertical") * 2;

    private void Update()
    {
        _rb.velocity = _moveDirection;
    }

    private void FixedUpdate()
    {
        _moveDirection = transform.right * horizontal + transform.forward * vertical;
        _moveDirection *= _moveSpeed * Time.deltaTime;

        if (_facingRight && horizontal < 0f || !_facingRight && horizontal > 0f)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 scale = playerSprite.localScale;
        scale.x *= -1;
        playerSprite.localScale = scale;
    }
}
