using UnityEngine;
using System.Collections;  // Necesario para usar Corutinas
using TMPro;  // Necesario para usar TextMeshPro

public class BombPlacer : MonoBehaviour
{
    public GameObject bombPrefab;  // Asigna aquí el prefab de la bomba
    public Transform bombSpawnPoint;  // Lugar donde aparecerá la bomba
    public float bombCooldown = 5f;  // Tiempo de espera en segundos entre bombas
    public int bombCount = 10;  // Contador de bombas disponibles
    public TMP_Text bombCountText;  // Referencia al texto de la UI que muestra las bombas restantes
    private bool isOnCooldown = false;  // Verifica si la bomba está en cooldown

    void Start()
    {
        // Inicializa el contador de bombas en la UI al comenzar el juego
        UpdateBombCountUI();
    }

    void Update()
    {
        // Detectar la tecla E y verificar que haya bombas disponibles y que no haya cooldown
        if (Input.GetKeyDown(KeyCode.E) && bombCount > 0 && !isOnCooldown)
        {
            SpawnBomb();
            bombCount--;  // Reducir la cantidad de bombas disponibles
            UpdateBombCountUI();  // Actualizar la UI del contador
            StartCoroutine(BombCooldown());  // Iniciar la corutina para el cooldown
        }
    }

    void SpawnBomb()
    {
        if (bombPrefab != null && bombSpawnPoint != null)
        {
            // Instanciar la bomba en el punto especificado
            GameObject bomb = Instantiate(bombPrefab, bombSpawnPoint.position, Quaternion.identity);

            // Destruir la bomba después de 5 segundos
            Destroy(bomb, 5f); // Aquí también podrías poner un tiempo de destrucción diferente si lo prefieres
        }
        else
        {
            UnityEngine.Debug.LogWarning("Faltan referencias: Asigna el prefab de la bomba y el punto de spawn.");
        }
    }

    // Corutina para manejar el tiempo de cooldown
    IEnumerator BombCooldown()
    {
        isOnCooldown = true;  // Activar el cooldown
        yield return new WaitForSeconds(bombCooldown);  // Esperar el tiempo del cooldown
        isOnCooldown = false;  // Desactivar el cooldown
    }

    // Actualiza el contador de bombas en la UI
    void UpdateBombCountUI()
    {
        if (bombCountText != null)
        {
            bombCountText.text = "Bombas: " + bombCount.ToString();  // Actualiza el texto de la UI
        }
    }
}
