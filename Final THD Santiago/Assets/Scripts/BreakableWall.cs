using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public float explosionRadius = 5f; // Radio de explosión en el que la pared puede ser destruida

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisionó tiene el tag "Bomb" (asegúrate de que las bombas tengan este tag)
        if (other.CompareTag("Bomb"))
        {
            ExplodeNearby(other.gameObject);
        }
    }

    void ExplodeNearby(GameObject bomb)
    {
        // Verifica si la bomba está dentro del radio de la pared
        float distanceToBomb = Vector3.Distance(transform.position, bomb.transform.position);

        if (distanceToBomb <= explosionRadius)
        {
            Destroy(gameObject); // Destruye la pared
            UnityEngine.Debug.Log("Pared destruida por explosión!"); // Usar explicitamente UnityEngine.Debug
        }
    }
}
