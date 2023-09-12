using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 7.0f;
    [SerializeField] private float jumpForce;
    [SerializeField] private float raycastDistance;
    //private Vector3 dir;
    private Rigidbody rb;

    //[SerializeField] private float maxY;
    //[SerializeField] private float rX;              // rotacao
    [SerializeField] private Transform camPivot;    //
    [SerializeField] private Transform cam;         //
    [SerializeField] private Transform gun;         // 

    //[SerializeField] private Arma armaAtual;
    //[SerializeField] private Municao municaoAtual;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        Jump();
      
    }

    private void FixedUpdate()
    {
        Move();
       
    }

    private void Move()
    {

        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed;
        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement); //* Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(IsGrounded())
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
       return  (Physics.Raycast(transform.position, Vector3.down, raycastDistance));
    }
}
