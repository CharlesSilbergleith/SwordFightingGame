using UnityEngine;
using UnityEngine.SceneManagement;


public class QuitCreadits : MonoBehaviour
{
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            leave();
        }
    }
    public void leave() { 
        SceneManager.LoadScene("Main");
    }
}
