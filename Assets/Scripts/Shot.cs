using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed = 15;
    public float TimeAlive = 3;

    void Start()
    {
        Destroy(gameObject, TimeAlive);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemigos")
        {
            Zombie enemigo = collision.GetComponent<Zombie>();

            enemigo.Health -= 1000;
        }
    }
}