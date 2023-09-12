using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Arma : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform posBala;       // posicao da bala
    public GameObject bala;       // posicao da bala
    private GameObject bullet;
    private Rigidbody rb;

    //[SerializeField] private Municao municao;

    public AudioClip []audioClip;
    private AudioSource audioSource;


    public float EnergiaCinetica;
    public float massa ;



    public void Start()
    {
        //massa = massa / 1000.0f;
        posBala = transform.Find("PosBullet");
        //posBalaGO.GetComponent<GameObject>();
        audioSource = GetComponent<AudioSource>();
        // verificando, enfim, a funcao de tiro
        
    }

    public void Update()
    {
        //fire();

        // verificando a magnitude
        if (rb != null)
        {
            //veloAtual = rb.velocity.magnitude;
            //Debug.Log("Velocidade Atual: " + massa);
        }
    }
    public void fire()
    {
        // antes do contato com o hopUp só existe a velocidade linear
        // depois do contato existe também a velocidade angular, fazendo a bala girar chamado de backSpin
        //Debug.Log("Atirei!!!: ");
        // verificando se o botao de tiro foi ativado. Existe também o delay para o próximo tiro, calculado pela
        // variavel 'nextFire' e também é feita a verificação se existe bala ainda.
        if (Input.GetButtonDown("Fire1"))// && Time.time > nextFire)// && bullets > 0)
        {
            //Debug.Log("Atirei 2!!!: ");
            // som da bala 
            audioSource.clip = audioClip[0];
            audioSource.Play();

         
            // instanciei o objeto bala
            //Instantiate(bala, new Vector3(posBala.position.x, posBala.position.y, posBala.position.z), Quaternion.identity);
            bullet = Instantiate(bala, posBala.position, posBala.rotation);

            // pegando o rigidbody do objeto bala
            rb = bullet.GetComponent<Rigidbody>();

            // Calcula a velocidade inicial em pés por segundo
            float velocidadeMPS = Mathf.Sqrt((2 * EnergiaCinetica) / massa);
            Debug.Log("Velocidade Atual: " + velocidadeMPS);

            float velocidadeFPS = velocidadeMPS * 3.28084f;

            // normalizando a força
            Vector3 forcaNecessaria = massa * (velocidadeFPS)* posBala.forward.normalized ;

            // Aplica a força no sentido do cano da arma
            rb.AddForce(forcaNecessaria, ForceMode.Impulse);


        }
    }
}











//Debug.Log("Cliquei!" + teste);

// Calculando a força de arrasto (drag) oposta à direção da velocidade atual do objeto
//Vector3 forcaDeArrasto = -rb.velocity.normalized * rb.drag;

// Calculando a força resultante que será aplicada ao objeto (força desejada + força de arrasto)
//Vector3 forcaResultante = new Vector3(0, 0, aceleracao) + forcaDeArrasto;

// Aplicando a força no objeto
//rb.AddForce(forcaResultante);

// rb.AddForce(forcaAplicada.normalized * (EnergiaCinetica - rb.drag * rb.velocity.magnitude));

// aqui o código para movimentar o gatilho da arma
// ------------------------------------------------
// ....
// ------------------------------------------------