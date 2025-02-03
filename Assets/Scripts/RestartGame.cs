using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void ReiniciarJogo()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
