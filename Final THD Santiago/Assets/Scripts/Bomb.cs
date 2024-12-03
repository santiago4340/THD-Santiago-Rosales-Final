using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5f;  // Rango de explosi�n (puedes ajustarlo desde el Inspector)
    public GameObject explosionEffect;  // Efecto visual de la explosi�n

    void Start()
    {
        // Se destruye la bomba despu�s de 5 segundos (o cualquier valor que determines)
        Destroy(gameObject, 5f);
    }

    void OnDestroy()
    {
        // Llamar a la funci�n de explosi�n cuando la bomba es destruida
        Explode();
    }

    void Explode()
    {
        // Crear el efecto visual de la explosi�n
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Detectar todos los objetos en el rango de explosi�n
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (var hitCollider in hitColliders)
        {
            // Si la colisi�n es con una pared, por ejemplo, destruirla
            if (hitCollider.CompareTag("BreakableWall"))
            {
                Destroy(hitCollider.gameObject);
            }
            // Puedes agregar m�s l�gica para otros objetos a ser afectados por la explosi�n
        }
    }
}
