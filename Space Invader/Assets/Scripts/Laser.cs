using UnityEngine;

public class Laser : MonoBehaviour
{
    // Configuration Parameters
    [Range(0f, 20f)][SerializeField] float laserSpeed = 10f;
    [SerializeField] bool isEnemyLaser = false;
    [SerializeField] AudioClip laserClip;
    [SerializeField] float laserClipVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, isEnemyLaser ? -laserSpeed : laserSpeed);
        AudioSource.PlayClipAtPoint(laserClip, Camera.main.transform.position, laserClipVolume);
    }
}
