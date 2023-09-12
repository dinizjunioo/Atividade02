using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour //, IDamageable
{

    //[SerializeField] private List<Gun> guns = new List<Gun>();

    public static WeaponHandler instance;

    private Transform cameraTransform;
    [SerializeField] private Gun currentGun;
    private GameObject currentGunPrefab;
    //public AudioClip[] audioClip;
    //private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        //currentGunPrefab = Instantiate(guns[0].gunPrefab, transform);
    }

    // Update is called once per frame
    private void Update()
    {
        CheckForShooting();
        //if(Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    Destroy(currentGunPrefab);
        //    currentGunPrefab = Instantiate(guns[0].gunPrefab, transform);
        //    currentGun = guns[0];
        //
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    Destroy(currentGunPrefab);
        //    currentGunPrefab = Instantiate(guns[1].gunPrefab, transform);
        //    currentGun = guns[1];
        //}
    }   

    public void PickUpGun(Gun gun)
    {
        if (currentGun != null)
        {
            Instantiate(currentGun.gunPickup, transform.position + transform.forward, Quaternion.identity);
            Destroy(currentGunPrefab);
        }
        currentGun = gun;
        currentGunPrefab = Instantiate(gun.gunPrefab, transform);
    }

    private void CheckForShooting()
    {

        //audioSource.clip = audioClip[0];
       // audioSource.Play();

        if (Input.GetMouseButtonDown(0))
        {
            //currentGun.OnMouseDown();
            currentGun.manual();
        //segurou 
        }else if(Input.GetMouseButton(0))
        {
            //currentGun.OnMouseHold();
            currentGun.automatic();
        }
    }

    public Gun gunActual()
    {
        Debug.Log("entrei");
        if(currentGun != null)
        {
            Debug.Log("entrei2");
            return currentGun;
        }
        Debug.Log("entre3");
        return null;
    }
}
