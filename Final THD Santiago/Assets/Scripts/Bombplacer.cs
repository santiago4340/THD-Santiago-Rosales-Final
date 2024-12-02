using UnityEngine;

public class BombPlacer : MonoBehaviour
{
    public GameObject bombPrefab;  // Asigna aqu� el prefab de la bomba
    public Transform bombSpawnPoint;  // Lugar donde aparecer� la bomba

    void Update()
    {
        // Detectar la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnBomb();
        }
    }

    void SpawnBomb()
    {
        if (bombPrefab != null && bombSpawnPoint != null)
        {
            // Instanciar la bomba en el punto especificado
            GameObject bomb = Instantiate(bombPrefab, bombSpawnPoint.position, Quaternion.identity);

            // Destruir la bomba despu�s de 5 segundos
            Destroy(bomb, 5f);
        }
        else
        {
            UnityEngine.Debug.LogWarning("Faltan referencias: Asigna el prefab de la bomba y el punto de spawn.");
        }
    }
}
