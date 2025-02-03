using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Constants;
using UnityEngine.EventSystems;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField] private Button[] menuButtons;
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelHub;
    [SerializeField] private MonoBehaviour playerMovementScript;
    [SerializeField] private MonoBehaviour cameraScript;
    private int currentIndex = 0;
    private Vector3 originalScale;
    public float focusScaleMultiplier = 1.2f;
    private bool canNavigate = true;
    public float inputCooldown = 0.2f;

    void Start()
    {
        if (menuButtons.Length > 0)
        {
            originalScale = menuButtons[0].transform.localScale;
            SelectButton(currentIndex);
            menuButtons[0].onClick.AddListener(ContinueGame);
            menuButtons[1].onClick.AddListener(QuitToMainMenu);
        }

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
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (canNavigate)
        {
            if (verticalInput > 0)
            {
                Navigate(-1);
            }
            else if (verticalInput < 0)
            {
                Navigate(1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            menuButtons[currentIndex].onClick.Invoke();
            panelPause.SetActive(true);
            panelHub.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            InvokeSelectedButton();
        }

        if (panelPause.activeSelf)
        {
            playerMovementScript.enabled = false;
            cameraScript.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            if (playerMovementScript != null) {
                playerMovementScript.enabled = true;
                cameraScript.enabled = true;
                Cursor.lockState = CursorLockMode.None;
            }
           
        }
    }

    private void InvokeSelectedButton()
    {
        menuButtons[currentIndex].onClick.Invoke();
    }

    private void Navigate(int direction)
    {
        canNavigate = false;
        menuButtons[currentIndex].transform.localScale = originalScale;
        currentIndex = (currentIndex + direction + menuButtons.Length) % menuButtons.Length;
        SelectButton(currentIndex);
        Invoke(nameof(ResetNavigation), inputCooldown);
    }

    private void SelectButton(int index)
    {
        menuButtons[index].Select();
        menuButtons[index].transform.localScale = originalScale * focusScaleMultiplier;
    }

    private void ResetNavigation()
    {
        canNavigate = true;
    }

    public void ContinueGame()
    {
        if (panelPause.activeSelf)
        {
            panelPause.SetActive(false);
            panelHub.SetActive(true);
        }
    }

    private void QuitToMainMenu()
    {
        SceneManager.LoadScene(GameConstants.SceneStart);
    }
}
