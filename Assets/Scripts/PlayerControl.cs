using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public FixedJoystick joystick;

    public float speed = 10f;

    public GameObject laserPrefab;

    public Transform firePoint;

    AudioSource audioSource;

    public AudioSource gameOverAudio;

    bool rapidFireActive = false;

    public bool fireButtonPressed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // MOVEMENT

        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;

        transform.Translate(
            new Vector2(moveX, moveY) *
            speed *
            Time.deltaTime
        );

        // SCREEN LIMITS

        float clampedX =
            Mathf.Clamp(transform.position.x, -7f, 7f);

        float clampedY =
            Mathf.Clamp(transform.position.y, -10f, 15f);

        transform.position =
            new Vector2(clampedX, clampedY);

        // SHOOTING

        if(Input.GetKeyDown(KeyCode.Space) || fireButtonPressed)
        {
            fireButtonPressed = false;

            if(rapidFireActive)
                {

                        Invoke("Shoot", 0f);
                        Invoke("Shoot", 0.1f);
                        Invoke("Shoot", 0.2f);
                }
            else
            {
                Shoot();
            }
        }

        // SHIP TILT

        Quaternion targetRotation =
            Quaternion.Euler(0, 0, -moveX * 20f);

        transform.rotation =
            Quaternion.Lerp(
                transform.rotation,
                targetRotation,
                5f * Time.deltaTime
            );
    }

    public void Shoot()
    {
        Instantiate(
            laserPrefab,
            firePoint.position,
            firePoint.rotation
        );

        audioSource.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // POWERUP

        if(other.CompareTag("Powerup"))
        {
            rapidFireActive = true;


            Destroy(other.gameObject);

            Invoke("ResetRapidFire", 5f);
        }

        // ASTEROID HIT

        if(other.CompareTag("Asteroid"))
        {
            GameObject.Find("soundmanager")
                .GetComponent<AudioSource>()
                .Stop();

            gameOverAudio.Play();

            Invoke("FreezeGame", 1f);

            GameObject gameManager =
                GameObject.Find("GameManager");

            gameManager
                .GetComponent<GameOverManager>()
                .ShowGameOver();
        }
    }

    void ResetRapidFire()
    {
        rapidFireActive = false;
    }

    void FreezeGame()
    {
        Time.timeScale = 0f;
    }
}