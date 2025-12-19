using UnityEngine;

public class SFXManger : MonoBehaviour
{
    public static SFXManger Instance;
    public AudioClip swordSwing;
    public AudioClip SwordSheath;
    public AudioClip axe;
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
  
}
