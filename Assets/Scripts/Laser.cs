using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject explosionPrefab;
    
    public float speed = 15f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        Destroy(gameObject, 5f);
    }

   void OnTriggerEnter2D(Collider2D other)
{
    if(other.CompareTag("Asteroid"))
    {
        ScoreManager.instance.AddScore(10);

        Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);

        other.GetComponent<Asteroid>().TakeDamage();

        Destroy(gameObject);
    }
}
}