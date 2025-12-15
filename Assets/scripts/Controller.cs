using UnityEngine;

public class Controller : MonoBehaviour
{

    public Pawn pawn;
    [SerializeField] private bool cursorLocked = true;
    [SerializeField] private float turnDirection;
    [SerializeField] private Transform focusPoint;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float max = 1f;
    [SerializeField] private Vector3 relativeVector; // used for mouse looking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }



    void Update()
    {
        bool isMoving = false;

        // FORWARD
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;

            if (Input.GetKey(KeyCode.LeftShift))
                pawn.Forward(pawn.runSpeed);
            else
                pawn.Forward(pawn.walkSpeed);
        }

        // BACK
        if (Input.GetKey(KeyCode.S))
        {
            isMoving = true;

            if (Input.GetKey(KeyCode.LeftShift))
                pawn.Back(pawn.runSpeed);
            else
                pawn.Back(pawn.walkSpeed);
        }

        // LEFT
        if (Input.GetKey(KeyCode.A))
        {
            isMoving = true;

            if (Input.GetKey(KeyCode.LeftShift))
                pawn.Left(pawn.runSpeed);
            else
                pawn.Left(pawn.walkSpeed);
        }

        // RIGHT
        if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;

            if (Input.GetKey(KeyCode.LeftShift))
                pawn.Right(pawn.runSpeed);
            else
                pawn.Right(pawn.walkSpeed);
        }

        // JUMP
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pawn.Jump();
        }

        // IF NOT MOVING ? RESET BLEND TREE
        if (!isMoving)
        {
            pawn.StopMoving();
        }


    }





}
