using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] GameObject laserPrefab;
    [Range(0f, 0.5f)][SerializeField] float firePeriod = 0.05f;
    [Range(0f, 20f)][SerializeField] float inputSensitivity = 10f;
    [Range(0f, 2f)][SerializeField] float boundaryPadding = 1f;
    [Range(0f, 10f)][SerializeField] float topBoundaryPadding = 1f;

    // State variables
    private float screenLeftBorder;
    private float screenRightBorder;
    private float screenBottomBorder;
    private float screenTopBorder;
    Coroutine fireCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * inputSensitivity * Time.deltaTime;
        var deltaY = Input.GetAxis("Vertical") * inputSensitivity * Time.deltaTime;
        var newPosX = Mathf.Clamp((transform.position.x + deltaX), screenLeftBorder, screenRightBorder);
        var newPosY = Mathf.Clamp((transform.position.y + deltaY), screenBottomBorder, screenTopBorder);
        transform.position = new Vector2(newPosX, newPosY);
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            Instantiate(laserPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(firePeriod);
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        screenLeftBorder = gameCamera.ViewportToWorldPoint(new Vector3(0, 0 , 0)).x + boundaryPadding;
        screenRightBorder = gameCamera.ViewportToWorldPoint(new Vector3(1, 0 , 0)).x - boundaryPadding;
        screenBottomBorder = gameCamera.ViewportToWorldPoint(new Vector3(0, 0 , 0)).y + boundaryPadding;
        screenTopBorder = gameCamera.ViewportToWorldPoint(new Vector3(0, 1 , 0)).y - topBoundaryPadding;
    }
}
