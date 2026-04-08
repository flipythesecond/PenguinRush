using UnityEngine;
using UnityEngine.U2D;
public class PlatformBehaviour : MonoBehaviour
{

    public GameObject ssPrefab;
    public Transform player;
    public float spawnThreshold = 5f;
    public float destroyThreshold = 10f;

    private Vector3 lastEndPosition = Vector3.zero;
    private System.Collections.Generic.List<GameObject> activeChunks = new System.Collections.Generic.List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Update is called once per frame
    void Update()
    {
       
        if (Vector3.Distance(player.position, lastEndPosition) < spawnThreshold)
        {
            SpawnNewChunk();
        }

        if (activeChunks.Count > 0 && player.position.x - activeChunks[0].transform.position.x > destroyThreshold)
        {
            GameObject oldChunk = activeChunks[0];
            activeChunks.RemoveAt(0);
            DestroyOldChunk();
        }
        
    }

    void SpawnNewChunk()
    {
        GameObject newChunk = Instantiate(ssPrefab, lastEndPosition, Quaternion.identity);
        SpriteShapeController controller = newChunk.GetComponent<SpriteShapeController>();

        ModifySpline(controller.spline);

        lastEndPosition += new Vector3(10f, 0, 0); // Assuming each chunk is 10 units wide
        activeChunks.Add(newChunk);
    }

    void ModifySpline(Spline spline)
    {
        for (int i = 0; i < spline.GetPointCount(); i++)
        {
            Vector3 posistion = spline.GetPosition(i);
            posistion.y = Mathf.PerlinNoise(posistion.x * 0.1f, 0) * 2f;
            spline.SetPosition(i, posistion);
        }
    }
}
