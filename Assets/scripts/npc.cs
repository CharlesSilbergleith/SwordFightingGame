using UnityEngine;
using UnityEngine.AI;



[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class NPC : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Vector3 destinationVector;
    public float front, side, state ; // animator floats
    public float roamTime, maxRoamDistanse,timeTillRoam, ranX, ranZ; // roam floats
    public float radiusForState, resetStateTimer, timeTillReset,radiusForAttack; // flaots for attacking
    public Collider[] hitColliders, attackSphere;
    public Pawn pawnHit, pawnInrange;
    public Pawn pawn;
    public Health health;
    public GameObject Hip;
    public Weapon weapon;
    public AudioSource source;














    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManger.Instance.EnemysLeft++;
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        weapon = GetComponentInChildren<Weapon>();
        source = GetComponent<AudioSource>();
        NPCManager.Instance.RegisterNPC(this, transform);

    }

    // Update is called once per frame
    void Update()
    {
        
        hitColliders = Physics.OverlapSphere(transform.position, radiusForState);
        for (int i =0; i< hitColliders.Length; i++){
            pawnHit = hitColliders[i].GetComponent<Pawn>();

            if (pawnHit != null)
            {
                
                state = 1;
                break;

            }
            else
            {
                state = 0;
            }
            
        }
        ifDead();
        animation();
        Roam();
        attck();

    }

 
    
    void Roam() {

        if (state != 0) return;
        ifDead();
        navMeshAgent.isStopped = false;
        // If NPC has reached destination  reset state
        if (!navMeshAgent.pathPending &&
            navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
            {
                state = 0;
                front = 0;
            }
        }
       

        if (Time.time > roamTime) {
            roamTime = Time.time + timeTillRoam;
            front = 1;
            float ran = Random.Range(0, 2);
            ranX = transform.position.x + Random.Range(maxRoamDistanse/2 , maxRoamDistanse)* (ran == 1 ? 1 : -1);
            ranZ = transform.position.z + Random.Range(maxRoamDistanse / 2, maxRoamDistanse) * (ran == 1 ? 1 : -1);
            destinationVector = new Vector3(ranX, 0, ranZ);
            navMeshAgent.SetDestination(destinationVector);
            
        }


    }
    void attck() { 
        if (state== 0) return;
        ifDead();
        navMeshAgent.SetDestination(GameManger.Instance.pawn.returnPosition() );
        attackSphere = Physics.OverlapSphere(transform.position, radiusForAttack);
        for (int i = 0; i < attackSphere.Length; i++)
        {
            pawnHit = hitColliders[i].GetComponent<Pawn>();
            pawnInrange = attackSphere[i].GetComponent<Pawn>();

            if (pawnHit != null)
            {
                
                animator.SetTrigger("hit");


            }
            
           

        }


    }
    void ifDead() {
        if (health.health <= 0)
        {
            navMeshAgent.isStopped = true;
            

        }

    }

    void animation() {
        animator.SetFloat("front", front);
        animator.SetFloat("side",side);
        animator.SetFloat("state",state);

    }
    public void State()
    {
        if (state == 0)
        {
            state = 1;

        }
        else
        {
            state = 0;
        }

    }
    public void EnableWeaponHit()
    {
        Debug.Log("EnableWeaponHit");


        weapon.EnableHit();
    }

    public void DisableWeaponHit()
    {
        Debug.Log("DisableWeaponHit");

        weapon.DisableHit();
    }

    public void AxeSound() {
        source.Play();
    }


}
