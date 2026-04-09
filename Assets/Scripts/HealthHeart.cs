using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{

    public Sprite fullHeart, halfHeart, emptyHeart; 
    Image heartImage; 

    private void Awake(){
        heartImage = GetComponent<Image>();
    } 

    public void SetHeartImage(HeartStatus status){
        switch (status){
            case HeartStatus.Empty:
                heartImage.sprite = emptyHeart;
                break;
            case  HeartStatus.Half:
                heartImage.sprite = halfHeart;
                break;
            case HeartStatus.Full:
                heartImage.sprite = fullHeart;
                break;
        }
    }

    // Start is called once before the first execution o Update after the MonoBehaviour is created 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum HeartStatus {
     Empty = 0,
     Half = 1,
     Full = 2
}
