using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float forwardSpeed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float jumpPower;
    private Vector3 _velocity = new Vector3();
    [SerializeField] bool isGrounded;
    [SerializeField] float maxHorizontalDistance;
    private Vector3 clampedPosition;
    public void Jump()
    {
        if (!GameInstance.Instance.isGameStarted)
        {
            _velocity = Vector3.zero;
            return;
        }
        else
        {
            isGrounded = Physics.Raycast(rb.position, Vector3.down, 0.51f);
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                _velocity.y = jumpPower;
                rb.velocity = _velocity;
                isGrounded = false;
            }
        }
        //Debug.LogWarning(isGrounded);

    }

    public void Move()
    {
        if (!GameInstance.Instance.isGameStarted)
        {
            _velocity = Vector3.zero;
            return;
        }
        //if (!GameInstance.Instance.isGameLost)
        //{
        //    _velocity = Vector3.zero;
        //    rb.position = Vector3.zero;
        //    return;
        //}

        if (Mathf.Abs(rb.position.x) > maxHorizontalDistance)
        {
            clampedPosition = rb.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -maxHorizontalDistance, maxHorizontalDistance);
            rb.position = clampedPosition;
        }
        GetVelocity();
    }
    public void GetVelocity()
    {
        _velocity.x = Input.GetAxis("Horizontal") * horizontalSpeed;
        _velocity.y = rb.velocity.y;
        _velocity.z = forwardSpeed;
        rb.velocity = _velocity;

    }

    private void Update()
    {
        Jump();
    }
    private void FixedUpdate()
    {

        Move();
    }

}
