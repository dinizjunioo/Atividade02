using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionPickup : MonoBehaviour
{
    [SerializeField] private int ammunitionCount;
    [SerializeField] private AmmunitionTypes ammunitionType;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<PlayerController>() != null)
        {
            AmmunitionManager.instance.AddAmmunition(ammunitionCount, ammunitionType);

            Debug.Log($"Adicionei {ammunitionCount} balas de {ammunitionType}");
            Destroy(gameObject);
        }
    }
}
