using UnityEngine;

public class DeathNPC : Death
{
    public Animator animator;
    public Collider collider;
    void Start() {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();

    }
    public void DestroySelf()
    {
        GameManger.Instance.EnemysLeft--;
        Destroy(gameObject);
    }
    public override void die() { 
        collider.enabled = false;
        animator.SetBool("dead",true);


    }

            
        
}//end of death
