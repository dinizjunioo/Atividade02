using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour, Ilootable
{
    [SerializeField] private Gun gun;

    public void OnInteract()
    {
        WeaponHandler.instance.PickUpGun(gun);
        Destroy(gameObject);
    }

    public void OnStartLook()
    {

    }

    public void OnEndLook()
    {

    }

}
