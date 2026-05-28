using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        transform.Translate(
            Vector2.down * speed * Time.deltaTime,
            Space.World
        );

        if(transform.position.y < -14f)
        {
            Destroy(gameObject);
        }
    }
}