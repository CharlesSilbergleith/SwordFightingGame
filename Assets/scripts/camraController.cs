using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("References")]
    public Transform player;       // The player object to orbit around
    public Transform camPivot;     // Empty pivot object
    public Camera playerCam;       // The actual camera

    [Header("Settings")]
    public float mouseSensitivity = 200f;
    public float minPitch = -60f;
    public float maxPitch = 60f;

    private float yaw = 0f;
    private float pitch = 0f;
    private bool cursorLocked = false;

    void Start()
    {
        // initialize starting orientation
        Vector3 rot = camPivot.localEulerAngles;
        yaw = rot.y;
        pitch = rot.x;

        LockCursor();  // start unlocked
    }

    void Update()
    {
        // Toggle cursor lock
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cursorLocked = !cursorLocked;

            if (cursorLocked)
                LockCursor();
            else
                UnlockCursor();
        }

        if (cursorLocked)
            HandleMouseInput();
    }

    void HandleMouseInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch -= mouseY;

        // clamp vertical rotation
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // rotate horizontal around player
        player.rotation = Quaternion.Euler(0f, yaw, 0f);

        // rotate vertical pivot
        camPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
