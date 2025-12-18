using UnityEngine;
using UnityEngine.UI;


public class HealthNPC : Health
{
    public Slider healthSlider;
    void Start() {
        healthSlider = GetComponentInChildren<Slider>();
        death = GetComponent<Death>();
    }
    void Update() {
        healthSlider.value = health/maxHealth;
    }



}
