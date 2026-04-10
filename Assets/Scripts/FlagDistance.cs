using UnityEngine;
using UnityEngine.UI;
public class FlagDistance : MonoBehaviour
{
    public Transform player;
    public Transform flag;
    public Slider progressBar;

    private float startDistance;
    private float endDistance;

    void Start()
    {
        if (player != null && flag != null)
        {
            startDistance = player.position.x;
            endDistance = flag.position.x;
        }

        if (progressBar != null)
        {
            progressBar.minValue = 0;
            progressBar.maxValue = 1f;
            progressBar.value = 0f;
        }
    }

    void Update()
    {
        if(player == null || flag == null || progressBar == null)
        {
            return;
        }

        float totalDistance = endDistance - startDistance;
        if (totalDistance <= 0f)
        {
            return;
        }

        float currentDistance = (player.position.x - startDistance) / totalDistance;
        currentDistance = Mathf.Clamp01(currentDistance);

        progressBar.value = currentDistance;
    }
}
