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
    public float roamTime, maxRoamDistanse, ranX, ranZ; // roam floats
   















    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        animation();
        Roam();


    }

 
    
    void Roam() {


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
        if (state != 0) return;

        if (Time.time > roamTime) {
            roamTime = Time.time + 20f;
            front = 1;
            float ran = Random.Range(0, 2);
            ranX = transform.position.x + Random.Range(maxRoamDistanse/2 , maxRoamDistanse)* (ran == 1 ? 1 : -1);
            ranZ = transform.position.z + Random.Range(maxRoamDistanse / 2, maxRoamDistanse) * (ran == 1 ? 1 : -1);
            destinationVector = new Vector3(ranX, 0, ranZ);
            navMeshAgent.SetDestination(destinationVector);
            
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

   


}
