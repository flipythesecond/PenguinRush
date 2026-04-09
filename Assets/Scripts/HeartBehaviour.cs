using UnityEngine;
using System.Collections;
public class HeartBehaviour : MonoBehaviour
{

    public GameObject heartPrefab; 
    public float health, maxHealth;
    List<HealthHeart> hearts = new List<HealthHeart>();


    public void CreateEmptyHeart(){
         GameObject newHeart = Instantiate(heartPrefab);
         newHeart.transform.SetParent(transform);

         HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
         heartComponent.SetHeartImage(HeartStatus.Empty);
         hearts.Add(heartComponent); 
    }

    public void DrawHearts(){
         ClearHearts();

         //determine how many hearts to make depening on health 

         float maxHeartRemainder = playerHealth.maxHealth % 2; 
         int heartsToMake = (int)((playerHealth.maxHealth / 2) + maxHealthRemainder); 

         for(int i = 0; i  < heartsToMake; i++)
         {
             CreateEmptyHeart();
         }
    }
    public void ClearHearts(){
        foreach(Transform t in transform)
        {
            Destroy(t.GameObject);
        }
        hearts = new List<HealthHeart>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
