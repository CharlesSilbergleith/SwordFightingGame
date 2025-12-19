using UnityEngine;

public class Weapon : MonoBehaviour
{
    public MeshRenderer renderer;
    public Collider hitCollider;
    public float dmg;



     void Awake()
    {
        hitCollider = GetComponent<Collider>();
        hitCollider.enabled = false;
    }

    public void EnableHit()

    {

        hitCollider.enabled = true;
    }

    public void DisableHit()
    {
        hitCollider.enabled = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setVisable() { 
        renderer.enabled = true;
    }
    public void setInvisable() { 
        renderer.enabled= false;
    }
    void OnTriggerEnter(Collider other)
    {
        

        NPC enemy = other.GetComponentInParent<NPC>();
        Health enemyHealth = other.GetComponentInParent<Health>();

        if (enemy != null)
        {
            enemyHealth.Damage(dmg);
        }
    }


}
