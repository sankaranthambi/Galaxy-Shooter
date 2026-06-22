using UnityEngine;

public class Asteroid : MonoBehaviour
{   CameraShake camShake;
    public static float globalSpeed;

    public const float defaultSpeed = 5f;
    public AudioClip hitSound;
    public AudioClip destroySound;

    float randomExtraSpeed;

    int health;

    void Start()
    {
        camShake = Camera.main.GetComponent<CameraShake>();
        randomExtraSpeed = Random.Range(0f, 2f);

        float size = transform.localScale.x;

        health = Mathf.RoundToInt(size * 2);
    }

    void Update()
    {
        float finalSpeed = globalSpeed + randomExtraSpeed;

        transform.Translate(
            Vector2.down * finalSpeed * Time.deltaTime,
            Space.World
        );

        transform.Rotate(0, 0, 100 * Time.deltaTime);

        if(transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage()
{
    health--;

    if(health <= 0)
    {
        AudioSource.PlayClipAtPoint(
            destroySound,
            transform.position
        );

        Destroy(gameObject);
        camShake.Shake(0.15f);
    }
    else
    {
        AudioSource.PlayClipAtPoint(
            hitSound,
            transform.position
        );
    }
}
}