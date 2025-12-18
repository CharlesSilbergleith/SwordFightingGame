using UnityEngine;

public class DeathNPC : Death
{
    public Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    public override void die() { 
        animator.SetBool("dead",true);

    }

            
        
}//end of death
