using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
       [SerializeField] private float _forwardSpeed;
       [SerializeField] private float _speed = 5f;

       [SerializeField] private float _horizontalSpeed;
       [SerializeField] private float _verticalSpeed;

       [SerializeField] private float _jumpForce;
       [SerializeField]
       private float maxLeft;
       [SerializeField]
       private float maxRight;
   
       [SerializeField] private Rigidbody _rigidbody;
   	
       private Vector3 _velocity = new Vector3();
       
       private bool _isGrounded;
   
       private void Start()
       {
           _rigidbody = GetComponent<Rigidbody>();
       }
   
       private void Update()
       {
           // var horizontalInput = Input.GetAxis("Horizontal");
           // var verticalInput = Input.GetAxis("Vertical");
           
           
           if (Input.GetKey(KeyCode.UpArrow))
           {
               transform.Translate(Vector3.forward * _speed * Time.deltaTime);

           }
           
           if (Input.GetKey(KeyCode.LeftArrow))
           {
               transform.Translate(Vector3.left * _speed * Time.deltaTime);
           }
           
           if (Input.GetKey(KeyCode.RightArrow))
           {
               transform.Translate(Vector3.right * _speed * Time.deltaTime);
           }
           

           var pos = transform.position;
           pos.x = Mathf.Clamp(pos.x, maxLeft, maxRight);
           transform.position = pos;
           
           _rigidbody.velocity = _velocity;

           if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
           {
               // _rigidbody.AddForce(Vector3.up * 6f, ForceMode.Impulse);
               // _isGrounded = false;
               _velocity.y += Mathf.Sqrt(_jumpForce * -3.0f * Physics.gravity.y);
           }
           
           _velocity.y += Physics.gravity.y * Time.deltaTime;
       }
   
       
       private void FixedUpdate()
       {
           _isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
       }
}
