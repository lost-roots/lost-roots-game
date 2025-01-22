using UnityEngine;
using UnityEngine.SceneManagement;
using Constants;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(GameConstants.SceneHub);
        }
    }

}
