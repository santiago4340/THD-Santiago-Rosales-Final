using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;  // Referencia al jugador
    public float visionRadius = 10f;  // Radio en el que el enemigo puede ver al jugador
    public float moveSpeed = 3f;  // Velocidad del movimiento del enemigo
    public int damage = 30;  // Daño que el enemigo hace al jugador

    private bool playerInRange = false;  // Si el jugador está dentro del rango de visión

    void Update()
    {
        // Comprobar si el jugador está dentro del rango de visión
        if (Vector3.Distance(transform.position, player.position) <= visionRadius)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }

        // Si el jugador está en rango, mover al enemigo hacia él
        if (playerInRange)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        // Mover al enemigo hacia la posición del jugador
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    // Función que se activa cuando el enemigo colisiona con el jugador
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Llamar la función de TakeDamage en el jugador cuando el enemigo lo toque
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
