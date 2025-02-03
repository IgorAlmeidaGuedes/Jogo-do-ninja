using UnityEngine;

public class BolaPingPong : MonoBehaviour
{
    public float velocidade = 2f;
    private int direcao = 1;
    private float posicaoY;
    public LayerMask layerChao; // Layer das paredes

    void Start()
    {
        posicaoY = transform.position.y; 
    }

    void Update()
    {
        transform.position += new Vector3(direcao * velocidade * Time.deltaTime, 0, 0);

        if (Physics2D.Raycast(transform.position, Vector2.right * direcao, 0.6f, layerChao))
        {
            direcao *= -1; // Inverte a direção ao detectar parede
        }
        
        transform.position = new Vector3(transform.position.x, posicaoY, transform.position.z);
    }
}
