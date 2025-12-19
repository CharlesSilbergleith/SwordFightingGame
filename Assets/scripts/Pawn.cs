using UnityEngine;

public class Pawn : MonoBehaviour
{

    [Header("movement")]

    public CharacterController characterController;

    public float gravity = -9.81f;
    public float vertcalSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float jumpHeight = 2f;

    [Header("Animation")]
    public Animator animator;
    public float state;

    [Header("Wepons")]
    public Weapon weapon;
    public GameObject weaponPoint;
    public int currentWeapon;

    [Header("health")]
    public Health health;
    public Death death;
    [Header("Audio")]
    public AudioClip slice;
    public AudioClip sheath;
    [SerializeField]private AudioSource source;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if( weapon!=null )  weapon.setInvisable();
        health = GetComponent<Health>();
        death = GetComponent<Death>();
        source = GetComponent<AudioSource>();


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
        animator.SetFloat("state", state);

    }

    // -------- Movement functions for Controller script ---------

    public void Forward(float speed)
    {
        if (speed != runSpeed)
        {
            animator.SetFloat("side", 0);
            animator.SetFloat("front", 1);
            animator.SetFloat("run", 0);
        }
        else {
            animator.SetFloat("run", 1);
        }


            characterController.Move(transform.forward * speed * Time.deltaTime);
    }


    public void Back(float speed)
    {
        animator.SetFloat("side", 0);
        animator.SetFloat("front", -1);

        characterController.Move(-transform.forward * speed * Time.deltaTime);
    }


    public void Right(float speed)
    {
        animator.SetFloat("side", 1);
        animator.SetFloat("front", 0);

        characterController.Move(transform.right * speed * Time.deltaTime);
    }


    public void Left(float speed)
    {
        animator.SetFloat("side", -1);
        animator.SetFloat("front", 0);

        characterController.Move(-transform.right * speed * Time.deltaTime);
    }
    public void StopMoving()
    {
        animator.SetFloat("side", 0);
        animator.SetFloat("front", 0);
        animator.SetFloat("run", 0);
    }


    // -------- Jump called by external Controller script ---------

    public void Jump()
    {
        if (characterController.isGrounded)
        {
            vertcalSpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void State() {
        if (state == 0)
        {
            state = 1;
            if (weapon != null) weapon.setVisable();

        }
        else { 
            state = 0;
            if (weapon != null) weapon.setInvisable();
        }

    }

    public void WeponSpawn()
    {
        if (weapon != null) return;

        weapon = Instantiate(
            GameManger.Instance.weapons[currentWeapon],
            weaponPoint.transform
        );

        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        weapon.transform.localScale = Vector3.one;
    }

    public void Slash() {
        if (state == 1)
        {

            animator.SetTrigger("attack");
            
        }

    }
    public void EnableWeaponHit()
    {
        if (weapon != null)
            weapon.EnableHit();
    }

    public void DisableWeaponHit()
    {
        if (weapon != null)
            weapon.DisableHit();
    }
    public Vector3 returnPosition() {
        return transform.position;
    }
    public void SwingSound() {
        source.Play();
    }


}
