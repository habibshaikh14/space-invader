using UnityEngine;

public class Laser : MonoBehaviour
{
    // Configuration Parameters
    [Range(0f, 20f)][SerializeField] float laserSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
    }
}
