using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;  // Referencia al jugador
    public float visionRadius = 10f;  // Radio en el que el enemigo puede ver al jugador
    public float moveSpeed = 3f;  // Velocidad del movimiento del enemigo
    public int damage = 30;  // Da�o que el enemigo hace al jugador

    private bool playerInRange = false;  // Si el jugador est� dentro del rango de visi�n

    void Update()
    {
        // Comprobar si el jugador est� dentro del rango de visi�n
        if (Vector3.Distance(transform.position, player.position) <= visionRadius)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }

        // Si el jugador est� en rango, mover al enemigo hacia �l
        if (playerInRange)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        // Mover al enemigo hacia la posici�n del jugador
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    // Funci�n que se activa cuando el enemigo colisiona con el jugador
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Llamar la funci�n de TakeDamage en el jugador cuando el enemigo lo toque
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
