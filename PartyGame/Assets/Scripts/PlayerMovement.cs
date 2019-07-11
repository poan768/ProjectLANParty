using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    
    public Rigidbody rb;

    public float forwardForce = 20f, forwardForce_copy = 0;
    public float sidewayForce = 500f;
    

    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        //forwardForce_copy = forwardForce;
        //characterController = GetComponent<CharacterController>();
        //rb.useGravity = false;
        //rb.AddForce(0, 0, forwardForce);
        // rb.AddForce(0, 200, 2000 * Time.deltaTime);  <= keep going non stop.
    }

    public void Update()
    {
        Cube_ctrl();
        //transform.Translate(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));   // can use joystick.

        // This script moves the character controller forward
        // and sideways based on the arrow keys.
        // It also jumps when pressing space.
        // Make sure to attach a character controller to the same game object.
        // It is recommended that you make only one call to Move or SimpleMove per frame.

        /*if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            //moveDirection = new Vector3(0, 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }*/

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        //characterController.Move(moveDirection * Time.deltaTime); 
    }
    
    private void Cube_ctrl()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0, -50 * Time.deltaTime, 0);

        }
        if (Input.GetKey("d"))
        {
            this.transform.Rotate(0, 50 * Time.deltaTime, 0);
        }
        if (Input.GetKey("w"))
        {
            forwardForce_copy += 10 * Time.deltaTime;
            this.transform.Translate(Vector3.forward * forwardForce_copy * Time.deltaTime);
            //rb.AddForce(500 * Time.deltaTime, 0, 0);
        }
        else
        {
            if (forwardForce_copy >= 0)
            {
                forwardForce_copy -= 30 * Time.deltaTime;
                if (forwardForce_copy <= 0) forwardForce_copy = 0;
            }
            this.transform.Translate(Vector3.forward * forwardForce_copy * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            forwardForce_copy -= 10 * Time.deltaTime;
            this.transform.Translate(Vector3.forward * forwardForce_copy * Time.deltaTime);
            //rb.AddForce(-500 * Time.deltaTime, 0, 0);
        }
        else
        {
            if (forwardForce_copy >= 0)
            {
                forwardForce_copy += 30 * Time.deltaTime;
                if (forwardForce_copy <= 0) forwardForce_copy = 0;
            }
            this.transform.Translate(Vector3.forward * forwardForce_copy * Time.deltaTime);
        }
    }

    public void FixUpdate()
    {
        
        
        
    }
}
