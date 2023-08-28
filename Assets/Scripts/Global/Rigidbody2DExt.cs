using UnityEngine;

public static class Rigidbody2DExt
{

    public static void AddExplosionForce2D(this Rigidbody2D rb, Vector3 explosionOrigin, float explosionForce, float explosionRadius)
    {
        Vector3 direction = rb.transform.position - explosionOrigin;
        float forceFalloff = 1 - (direction.magnitude / explosionRadius);
        rb.AddForce(direction.normalized * (forceFalloff <= 0 ? 0 : explosionForce) * forceFalloff);
    }
}