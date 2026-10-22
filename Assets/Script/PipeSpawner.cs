using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipeTop;
    public GameObject pipeBottom;

    public float spawnTime = 2.5f;
    public float spawnX = 10f;
    public float gap = 3f;

    public float minCenterY = -0.5f;
    public float maxCenterY = 1.5f;

    private float timer;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        if (GameManager.gameOver)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            SpawnPipes();
            timer = 0f;
        }
    }

    void SpawnPipes()
    {
        if (pipeTop == null || pipeBottom == null)
        {
            Debug.LogError("PipeTop یا PipeBottom تنظیم نشده است!");
            return;
        }

        float centerY = Random.Range(minCenterY, maxCenterY);

        float topY = centerY + gap / 2f + 2f;
        float bottomY = centerY - gap / 2f - 2f;

        GameObject top = Instantiate(
            pipeTop,
            new Vector3(spawnX, topY, 0f),
            Quaternion.identity
        );

        GameObject bottom = Instantiate(
            pipeBottom,
            new Vector3(spawnX, bottomY, 0f),
            Quaternion.identity
        );

        GameObject zone = new GameObject("ScoreZone");
        zone.transform.position = new Vector3(spawnX, centerY, 0f);

        BoxCollider2D box = zone.AddComponent<BoxCollider2D>();
        box.isTrigger = true;
        box.size = new Vector2(0.5f, gap);

        zone.AddComponent<ScoreZone>();

        zone.transform.SetParent(top.transform, true);
    }
}