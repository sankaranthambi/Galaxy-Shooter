using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float speed = 2f;

    public float resetPosition = -38.95f;
    public float startPosition = 38.95f;

    void Update()
    {
        
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        speed = Asteroid.globalSpeed * 0.5f;

        if(transform.position.y <= resetPosition)
        {
            transform.position = new Vector2(
                transform.position.x,
                startPosition
            );
        }
    }
}