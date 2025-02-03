using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScrpit : MonoBehaviour
{
    public void IniciarJogo()
    {
        SceneManager.LoadScene("Game");
    }

}
