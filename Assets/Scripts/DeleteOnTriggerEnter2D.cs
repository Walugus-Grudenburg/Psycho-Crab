using UnityEngine;

public class DeleteOnTriggerEnter2D : MonoBehaviour
{
    [SerializeField] private string tagToDestroy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagToDestroy))
        {
            Destroy(other.gameObject);
        }
    }
}
