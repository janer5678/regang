using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zoom : MonoBehaviour
{
    public string farm, couch, josh_map;
    public Transform character; // Reference to the character's transform
    public Camera mainCamera; // Reference to the Camera
    public float zoomedInSize = 3f; // The camera size when zoomed in
    public float zoomSpeed = 5f; // Speed of zooming
    public Vector3 offset; // Offset from the character's position

    public float originalSize; // The original camera size
    private bool isZoomedIn = false;

    private float zoom_time_ = 0;
    private float cool_down_ = 0;
    Josh3Controls controls;
    float attack2;

    private void Awake()
    {
        controls = new Josh3Controls();

        controls.Josh2.Attack2.performed += ctx => attack13();

    }

    void attack13()
    {
        if (StaticScript.player3character == 8)
        {
            if (cool_down_ > 5)
            {
                isZoomedIn = !isZoomedIn; // Toggle zoom state
            }
        }
    }


    void OnEnable()
    {
        controls.Josh2.Enable();  // Ensure your action map is enabled
    }

    void OnDisable()
    {
        controls.Josh2.Disable(); // Disable to avoid memory leaks or errors
    }


    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Automatically get the main camera if not assigned
        }

        if (character == null)
        {
            Debug.LogError("Character not assigned to CameraZoomAndFollow script.");
        }

        originalSize = mainCamera.orthographicSize; // Store the original size

    }

    void Update()
    {
        if (StaticScript.player2character == 8)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && cool_down_ > 5)
            {
                isZoomedIn = !isZoomedIn; // Toggle zoom state
            }
        }
        else if (StaticScript.player1character == 8)
        {
            if (Input.GetKeyDown(KeyCode.Period) && cool_down_ > 5)
            {
                isZoomedIn = !isZoomedIn; // Toggle zoom state
            }
        }

        Scene scene = SceneManager.GetActiveScene();

        // Smoothly interpolate the camera size
        if (isZoomedIn)
        {
            if (scene.name == josh_map)
            {
                zoomedInSize = 1f;
            }
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoomedInSize, Time.deltaTime * zoomSpeed);
            mainCamera.transform.position = new Vector3(character.position.x + offset.x, character.position.y + offset.y, offset.z);
            zoom_time_ += Time.deltaTime;
            cool_down_ = 0;
        }
        else
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, originalSize, Time.deltaTime * zoomSpeed);
            
            if (scene.name == farm)
            {
                mainCamera.transform.position = new Vector3(10.6999998f, 4.5999999f, -10);
            }
            if (scene.name == couch)
            {
                mainCamera.transform.position =  new Vector3(0, 0, -10);
            }
            if (scene.name == josh_map)
            {
                mainCamera.transform.position = new Vector3(0, 0, -10);
            }


            zoom_time_ = 0;
            cool_down_ += Time.deltaTime;
        }

        if (zoom_time_ > 5 ) { isZoomedIn = false; }
    }
}
