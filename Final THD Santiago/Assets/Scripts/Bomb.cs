using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5f;  // Rango de explosión (puedes ajustarlo desde el Inspector)
    public GameObject explosionEffect;  // Efecto visual de la explosión

    void Start()
    {
        // Se destruye la bomba después de 5 segundos (o cualquier valor que determines)
        Destroy(gameObject, 5f);
    }

    void OnDestroy()
    {
        // Llamar a la función de explosión cuando la bomba es destruida
        Explode();
    }

    void Explode()
    {
        // Crear el efecto visual de la explosión
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Detectar todos los objetos en el rango de explosión
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (var hitCollider in hitColliders)
        {
            // Si la colisión es con una pared, por ejemplo, destruirla
            if (hitCollider.CompareTag("BreakableWall"))
            {
                Destroy(hitCollider.gameObject);
            }
            // Puedes agregar más lógica para otros objetos a ser afectados por la explosión
        }
    }
}
