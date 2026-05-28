using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameOverManager gameOverManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Asteroid"))
        {
            gameOverManager.GameOver();
        }
    }
}