
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        if (GameManager.gameOver)
            return;

        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }
}
