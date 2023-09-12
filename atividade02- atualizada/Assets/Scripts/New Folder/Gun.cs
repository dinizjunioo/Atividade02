using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName ="Gun")]
public class Gun : ScriptableObject
{
  
    [Header("status ")]
    public AmmunitionTypes ammunitionTypes;
    public string gunName;
    public GameObject gunPrefab;
    public GameObject gunPickup;
    
    [Header("status2 ")]
    public int minimumDamage;
    public int maximumDamage;
    public float maximumRange;
    private float lastTimeFired;
    public float fireRate;
    public virtual void OnMouseDown( )
    {

    }

    public virtual void OnMouseHold( )
    {

    }

    public void manual()
    {  
        Fire();
    }

    public void automatic()
    {
        if (Time.time - lastTimeFired > 1 / fireRate)
        {
            lastTimeFired = Time.time;
            Fire();
        }
    }

    protected void Fire()
    {
        if (AmmunitionManager.instance.ConsumeAmmo(ammunitionTypes))
        {

            // instanciei o objeto bala
            //Instantiate(bala, new Vector3(posBala.position.x, posBala.position.y, posBala.position.z), Quaternion.identity);
            Arma arma = FindObjectOfType<Arma>();
            arma.fire();
            AmmunitionManager.instance.GetAmmunitionCount(ammunitionTypes);
            //bullet = Instantiate(bala, posBala.position, posBala.rotation);
            //
            //// pegando o rigidbody do objeto bala
            //rb = bullet.GetComponent<Rigidbody>();
            //
            //// Calcula a velocidade inicial em pés por segundo
            //float velocidadeMPS = Mathf.Sqrt((2 * EnergiaCinetica) / massa);
            //Debug.Log("Velocidade Atual: " + velocidadeMPS);
            //
            //float velocidadeFPS = velocidadeMPS * 3.28084f;
            //
            //// normalizando a força
            //Vector3 forcaNecessaria = massa * (velocidadeFPS) * posBala.forward.normalized;
            //
            //// Aplica a força no sentido do cano da arma
            //rb.AddForce(forcaNecessaria, ForceMode.Impulse);

            // decrementando as balas
            //bullets--;
        }
    }
}
