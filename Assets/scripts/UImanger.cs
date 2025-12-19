using UnityEngine;
using UnityEngine.UI;

public class UImanger : MonoBehaviour
{
    public static UImanger Instance;
    public Image health;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {

        health.fillAmount = GameManger.Instance.pawn.health.healthPercent();
    }
}
