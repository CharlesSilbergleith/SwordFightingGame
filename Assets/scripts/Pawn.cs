using UnityEngine;

public class Pawn : MonoBehaviour
{
    public CharacterController characterController;

    public float gravity = -9.81f;
    public float vertcalSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float jumpHeight = 2f;
    public Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground check and gravity
        if (characterController.isGrounded)
        {
            if (vertcalSpeed < 0)
                vertcalSpeed = -2f;
        }
        else
        {
            vertcalSpeed += gravity * Time.deltaTime;
        }

        // Apply vertical movement
        Vector3 verticalMove = new Vector3(0, vertcalSpeed, 0);
        characterController.Move(verticalMove * Time.deltaTime);

        animator.SetBool("grounded", characterController.isGrounded);
        animator.SetFloat("jump", vertcalSpeed);

    }

    // -------- Movement functions for Controller script ---------

    public void Forward(float speed)
    {
        animator.SetFloat("vertical", 0);
        animator.SetFloat("Horizontal", 1);

        characterController.Move(transform.forward * speed * Time.deltaTime);
    }


    public void Back(float speed)
    {
        animator.SetFloat("vertical", 0);
        animator.SetFloat("Horizontal", -1);

        characterController.Move(-transform.forward * speed * Time.deltaTime);
    }


    public void Right(float speed)
    {
        animator.SetFloat("vertical", 1);
        animator.SetFloat("Horizontal", 0);

        characterController.Move(transform.right * speed * Time.deltaTime);
    }


    public void Left(float speed)
    {
        animator.SetFloat("vertical", -1);
        animator.SetFloat("Horizontal", 0);

        characterController.Move(-transform.right * speed * Time.deltaTime);
    }
    public void StopMoving()
    {
        animator.SetFloat("vertical", 0);
        animator.SetFloat("Horizontal", 0);
    }


    // -------- Jump called by external Controller script ---------

    public void Jump()
    {
        if (characterController.isGrounded)
        {
            vertcalSpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
