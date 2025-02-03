using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Referência ao player
    private float fixedY;   

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("A referência do Player na câmera não foi atribuída!");
            return;
        }

        fixedY = transform.position.y; // Mantém a altura inicial
    }

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, fixedY, transform.position.z);
        }
    }
}
    