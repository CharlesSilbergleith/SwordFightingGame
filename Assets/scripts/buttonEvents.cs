using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonEvents : MonoBehaviour
{
     public void StartButton() {
        SceneManager.LoadScene("playWorld");
    }
    public void Creadits() {
        SceneManager.LoadScene("Creadits");
    }
    public void Quit() {
        Application.Quit();
    }

   


}
