using UnityEngine;
using TMPro;  // Asegúrate de usar este espacio de nombres para TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Salud máxima del jugador
    private int currentHealth;  // Salud actual del jugador
    public Transform spawnPoint;  // Punto de inicio donde respawnea el jugador
    public TextMeshProUGUI healthText;  // Texto de la UI para mostrar la salud (con TextMeshPro)

    void Start()
    {
        currentHealth = maxHealth;  // Establece la salud inicial
        UpdateHealthUI();  // Actualiza la UI de la salud al inicio
    }

    // Función para reducir la vida cuando el jugador es tocado por el enemigo
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Vida restante: " + currentHealth);

        // Actualiza la UI de la salud cada vez que se recibe daño
        UpdateHealthUI();

        // Si el jugador se queda sin vida
        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    // Reinicia al jugador en el punto de spawn
    void Respawn()
    {
        transform.position = spawnPoint.position;  // Mueve al jugador al punto de inicio
        currentHealth = maxHealth;  // Restablece la salud al máximo
        UpdateHealthUI();  // Actualiza la UI de la salud
        Debug.Log("Jugador ha sido reiniciado.");
    }

    // Actualiza la UI del texto de la salud
    void UpdateHealthUI()
    {
        healthText.text = "Vida: " + currentHealth.ToString();  // Actualiza el texto de la UI con la salud
    }
}
