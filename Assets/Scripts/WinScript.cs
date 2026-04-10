using UnityEngine;
using UnityEngine.SceneManagement;
public class WinScript : MonoBehaviour
{
    public GameObject winPanel;
    private bool hasWon = false;


    void Start()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasWon)
        {
            return;
        }

        if (collision.CompareTag("Player"))
        {
            Win();
        }
    }

    void Win()
    {
        hasWon = true;

        if( winPanel != null)
        {
            winPanel.SetActive(true);
        }
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void GoHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
