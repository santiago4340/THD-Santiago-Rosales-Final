using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;  // Referencia al jugador
    public float visionRadius = 10f;  // Radio en el que el enemigo puede ver al jugador
    public float moveSpeed = 3f;  // Velocidad del movimiento del enemigo
    public Transform spawnPoint;  // Referencia al punto de inicio del jugador (punto de reaparición)

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

        // Mostrar en la consola que el enemigo está persiguiendo al jugador
        UnityEngine.Debug.Log("El enemigo está persiguiendo al jugador.");
    }

    // Función que se activa cuando el enemigo colisiona con el jugador
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reiniciar el jugador al punto de inicio cuando lo toque el enemigo
            UnityEngine.Debug.Log("El jugador ha sido tocado por el enemigo y será reiniciado.");
            ResetPlayerPosition();
        }
    }

    // Reinicia al jugador en el punto de spawn
    void ResetPlayerPosition()
    {
        if (spawnPoint != null)
        {
            player.position = spawnPoint.position;  // Mueve al jugador al punto de inicio
        }
        else
        {
            UnityEngine.Debug.LogError("No se ha asignado un punto de spawn.");
        }
    }
}
