using UnityEngine;

public class Health : MonoBehaviour
{
    public Death death;
    public float health;
    public float maxHealth;

    void Start() {
        death = GetComponent<Death>();
    }


    public void Heal()
    {
        Heal(10);

    }// end of heal

    public void Heal(float healAmount) {
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }

    public void Damage() {
        Damage(10);
    
    }
    public void Damage(float damageAmount) { 
        health -= damageAmount;
        if (health < 0) {
            death.die();
        }
    }




}// end of health class
