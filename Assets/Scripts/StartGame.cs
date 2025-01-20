using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private string nomeDaCena = "Cena01";
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("Uma tecla foi pressionada!");
            SceneManager.LoadScene(nomeDaCena);

        }
    }

}
