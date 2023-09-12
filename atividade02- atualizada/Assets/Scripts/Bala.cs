using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour//, IDamageable
{
    // Valor inicial de BackspinDrag
    private float BackspinDrag = 0.2f; 
    
    // 
    private Rigidbody rb;

    // tem acesso aos atributos do scriptable object da arma

    // referencia ao metodo "trocar arma" para conseguir a gun atual
    private WeaponHandler weaponHandler;

    // verifica se colidiu com o backSpin
    public bool colidiuHotUp = false;
    
    // posicao inicial da bala para calcular distancia percorrida
    private Vector3 initialPosition;


    // private float newForce;
    //public Transform posBala;       // posicao da bala
    void Start()
    {
        initialPosition = transform.position;
        //posBala = posBala.GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 10);
        Debug.Log("BackspinDrag Atual: " + BackspinDrag);
    }

    void Update()
    {
        //float velocidadeFPS = Mathf.Sqrt((2 * 1.49f) / (0.2f / 1000.0f));
        // Debug.Log("Velocidade Atual: " + velocidadeFPS * posBala.forward * (0.2f / 1000.0f));
        //rb.AddForce(posBala.forward * velocidadeFPS * 0.0002f, ForceMode.Force);

        if (colidiuHotUp)
        {
        //float velocidadeNoPlanoXZ = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
        // Calcule a força de sustentação com base na velocidade da BB no plano X-Z
        //float forcaDeSustentacao = Mathf.Sqrt(velocidadeNoPlanoXZ) * BackspinDrag;
        // Aplica a força de sustentação 
        //rb.AddForce(Vector3.up * forcaDeSustentacao * Time.deltaTime);
            Vector3 magnusDirection = Vector3.Cross(rb.velocity, transform.up).normalized;
            Vector3 magnusForce = Mathf.Sqrt(rb.velocity.magnitude) * magnusDirection * BackspinDrag * Time.fixedDeltaTime;
            rb.AddForce(magnusForce);
        }

        //Debug.DrawRay(transform.position, magnusForce * 1000, Color.red, Mathf.Infinity);

    }

    private void OnTriggerEnter(Collider other)
    {
        // se ele não se colidiu com nenhum objeto com a tag Gun (todas as partes da geometria da arma
        // e o HotUp tem tag Gun) então destrua o objeto bala imediatamente.
        if (other.gameObject.CompareTag("HotUp"))
        {
            Debug.Log("trigger com o HotUp ");
            colidiuHotUp = true;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("HotUp"))
        {
            Debug.Log("Trigger com o HotUp");
            colidiuHotUp = true;
        }

        

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // procurando pela 
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

            // pegando a arma atual por referencia
            Gun gun = GetComponent<WeaponHandler>().gunActual();

            //weaponHandler.gunActual();

            //Gun gun = weaponHandler.gunActual();  

            if (damageable != null && gun != null)
            {
                // Calcule a distância entre a posição inicial e o ponto de colisão.
                float distance = Vector3.Distance(initialPosition, collision.contacts[0].point);

                // Normaliza a distância no intervalo [0, 1] em relação à distância máxima.
                float normalisedDistance = Mathf.Clamp01(distance / gun.maximumRange);

                // Calcule o dano com base na distância normalizada.
                int damage = Mathf.RoundToInt(Mathf.Lerp(gun.maximumDamage, gun.minimumDamage, normalisedDistance));

                // Aplique o dano ao inimigo.
                damageable.danoCausado(damage);
            }
            Destroy(gameObject);
        }
    }

}
