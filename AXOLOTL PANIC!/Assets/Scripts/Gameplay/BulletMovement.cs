
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            Debug.Log("¡El jugador recibió un impacto! Juego pausado.");
        }

        Destroy(gameObject);
    }
}

