using UnityEngine;

public class BolaPingPong : MonoBehaviour
{
    public float velocidade = 2f;
    private int direcao = 1;
    private float posicaoY;
    public LayerMask layerChao; // Layer das paredes

    void Start()
    {
        posicaoY = transform.position.y; // Salva a posição Y inicial
    }

    void Update()
    {
        // Move apenas no eixo X
        transform.position += new Vector3(direcao * velocidade * Time.deltaTime, 0, 0);

        // Verifica se há parede à frente usando Raycast
        if (Physics2D.Raycast(transform.position, Vector2.right * direcao, 0.6f, layerChao))
        {
            direcao *= -1; // Inverte a direção ao detectar parede
        }

        // Mantém a posição Y fixa
        transform.position = new Vector3(transform.position.x, posicaoY, transform.position.z);
    }
}
