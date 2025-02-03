using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;
    public float forcaPulo = 10f;

    private Rigidbody2D rb;
    private bool estaNoChao = false;

    [Header("Verificação de Chão")]
    public Transform pontoVerificacao;
    public float raioVerificacao = 0.1f;
    public LayerMask camadaChao;

    [Header("Posição Inicial")]
    public float posicaoInicialX = 0.1f;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Vector3 posicaoInicial = transform.position;
        posicaoInicial.x = -10;
        transform.position = posicaoInicial;
    }

    void Update()
    {
        float movimento = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movimento * velocidade, rb.linearVelocity.y);

        anim.SetBool("Run", movimento != 0);

        // Pulo
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
            anim.SetTrigger("Jump");
        }
    }

    void FixedUpdate()
    {
        bool estavaNoChao = estaNoChao;
        estaNoChao = Physics2D.OverlapCircle(pontoVerificacao.position, raioVerificacao, camadaChao);

        // Se acabou de tocar o chão, resetamos a animação
        if (!estavaNoChao && estaNoChao)
        {
            anim.ResetTrigger("Jump");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Espinhos"))
        {
            SceneManager.LoadScene("LostGame"); // Troca para a cena de derrota
        }

        if (other.CompareTag("Vitoria"))
        {
            SceneManager.LoadScene("End"); // Troca para a cena de vitoria
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (pontoVerificacao == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pontoVerificacao.position, raioVerificacao);
    }
}
