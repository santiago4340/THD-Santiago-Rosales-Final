using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public float explosionRadius = 5f; // Radio de explosión en el que la pared puede ser destruida
    private bool isWaitingForExplosion = false;
    private float explosionTime = 0f;

    // Método que se activa cuando la bomba está cerca
    public void StartExplosionTimer(float timer)
    {
        isWaitingForExplosion = true;
        explosionTime = timer;
    }

    void Update()
    {
        // Si la pared está esperando la explosión, verifica si el tiempo ha pasado
        if (isWaitingForExplosion)
        {
            explosionTime -= Time.deltaTime; // Reducir el tiempo restante

            if (explosionTime <= 0f) // Si el tiempo se acaba
            {
                DestroyWall(); // Destruir la pared
                isWaitingForExplosion = false; // Detener la espera
            }
        }
    }

    // Método para destruir la pared
    void DestroyWall()
    {
        Destroy(gameObject);  // Destruye la pared
        UnityEngine.Debug.Log("Pared destruida por explosión!");
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisionó tiene el tag "Bomb"
        if (other.CompareTag("Bomb"))
        {
            // Iniciar el temporizador de explosión
            StartExplosionTimer(5f); // 5 segundos de espera
        }
    }
}
