using UnityEngine;
using System.Collections.Generic;

public class HeartUI : MonoBehaviour
{
    public GameObject heartPrefab;
    public Transform heartContainer;
    public float spaceBetweenHearts = 20f;


    private List<GameObject> hearts = new List<GameObject>();
    
    public void UpdateHearts(int currentHealth)
    {
        // Remove old hearts
        for (int i = 0; i < hearts.Count; i++)
        {
            {
                Destroy(hearts[i]);
            }
        }

        hearts.Clear();

        // Create new hearts based on current health
        for (int i = 0; i < currentHealth; i++)
        {
            GameObject newHeart = Instantiate(heartPrefab, heartContainer);
            RectTransform rt = newHeart.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector3 (i * spaceBetweenHearts, 0, 0);

            hearts.Add(newHeart);
        }
        
    }
    
    
  
}
