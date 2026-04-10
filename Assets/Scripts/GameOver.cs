using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    public GameObject GameOverPanel;
    public GameObject player;

    private bool isGameOver = false;
    
    void Start()
    {
        GameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver && player)
        {
            PlayerBehaviour pb = player.GetComponent<PlayerBehaviour>();

            if (pb == null)
            {
                ShowGameOver();
            }
        }
    }

    public void ShowGameOver()
    {
        isGameOver = true;
        GameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GoHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
