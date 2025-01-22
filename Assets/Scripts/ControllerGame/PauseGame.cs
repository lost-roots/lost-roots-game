using UnityEngine;
using UnityEngine.SceneManagement;
using Constants;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelHub;

    void Start()
    {
        if (panelPause != null)
        {
            panelPause.SetActive(false);
        }

        if (panelHub != null)
        {
            panelHub.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (panelPause != null && panelHub != null)
        {
            bool isPaused = panelPause.activeSelf;
            panelPause.SetActive(!isPaused);
            panelHub.SetActive(isPaused);
        }
    }

    public void ContinueGame()
    {
        if (panelPause != null && panelHub != null)
        {
            panelPause.SetActive(false);
            panelHub.SetActive(true);
        }
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(GameConstants.SceneStart); 
    }
}