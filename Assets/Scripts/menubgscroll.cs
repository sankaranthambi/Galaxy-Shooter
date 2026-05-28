using UnityEngine;

public class menubgscroll : MonoBehaviour
{
    public float speed = 1f;

    public float resetPosition = -16.25f;
    public float startPosition = 16.25f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if(transform.position.y <= resetPosition)
        {
            transform.position = new Vector2(
                transform.position.x,
                startPosition
            );
        }
    }
}