
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private bool scored = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (scored || !other.CompareTag("Player"))
            return;

        ScoreManager manager = FindFirstObjectByType<ScoreManager>();

        if (manager != null)
        {
            scored = true;
            manager.AddScore();
        }
    }
}
