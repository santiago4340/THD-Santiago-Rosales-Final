using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;  // Referencia al jugador
    public float visionRadius = 10f;  // Radio en el que el enemigo puede ver al jugador
    public float moveSpeed = 3f;  // Velocidad del movimiento del enemigo
    public Transform spawnPoint;  // Referencia al punto de inicio del jugador (punto de reaparici�n)

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

        // Mostrar en la consola que el enemigo est� persiguiendo al jugador
        UnityEngine.Debug.Log("El enemigo est� persiguiendo al jugador.");
    }

    // Funci�n que se activa cuando el enemigo colisiona con el jugador
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reiniciar el jugador al punto de inicio cuando lo toque el enemigo
            UnityEngine.Debug.Log("El jugador ha sido tocado por el enemigo y ser� reiniciado.");
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
