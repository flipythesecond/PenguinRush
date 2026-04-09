using UnityEngine;

public class MenuBehavior : MonoBehaviour
{

    public void gotoGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }

    public void gotoMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
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
