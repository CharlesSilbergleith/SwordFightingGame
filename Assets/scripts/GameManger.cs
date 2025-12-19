using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManger : MonoBehaviour
{
    public static GameManger Instance;
    public CameraController gameController;


    public Weapon[] weapons;
    public Pawn pawn;
    public NPC bandits;
    public float EnemysLeft;
    public bool gameWin;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController.LockCursor();

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemysLeft == 0) {
            
            Win();
        }
        
    }

    public void EndGame() {
        gameController.UnlockCursor();
        SceneManager.LoadScene("loose");

    }
    public void Win() {
        gameController.UnlockCursor();
        SceneManager.LoadScene("win");

    }
}
