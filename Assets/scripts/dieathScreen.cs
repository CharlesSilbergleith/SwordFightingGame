using UnityEngine;
using UnityEngine.SceneManagement;


public class dieathScreen : MonoBehaviour
{
    public float toMainTimer = 3f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= toMainTimer)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
