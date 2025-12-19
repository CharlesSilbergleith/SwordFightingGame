using UnityEngine;

public class npcWeapon : Weapon
{
   
    void OnTriggerEnter(Collider other)
    {
        Pawn player = other.GetComponentInParent<Pawn>();
        Health playerHealth = other.GetComponentInParent<Health>();

        if (player != null && playerHealth != null)
        {
            playerHealth.Damage(dmg);
        }
    }

}
