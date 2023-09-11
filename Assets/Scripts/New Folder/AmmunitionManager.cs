using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class AmmunitionManager : MonoBehaviour
{
    public static AmmunitionManager instance;

    [SerializeField] private TextAlignment AmmunitionCountText;

    public enum AmmunitionTypes
    {
        shotgun,
        pistol,
        rifle
    }

    private Dictionary<AmmunitionTypes, int> AmmunitionCounts = new Dictionary<AmmunitionTypes, int>();
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        for(int i = 0; i < Enum.GetNames(typeof(AmmunitionTypes)).Length; i++)
        {
            AmmunitionCounts.Add((AmmunitionTypes)i, 0);
        }
    }

    public void AddAmmunition(int value, AmmunitionTypes ammunitionTypes)
    {
        AmmunitionCounts[ammunitionTypes] += value;
        //UpdateAmmoCountUI();
    }

    public bool ConsumeAmmo(AmmunitionTypes ammunitionTypes)
    {
        if (AmmunitionCounts[ammunitionTypes] > 0)
        {
            AmmunitionCounts[ammunitionTypes]--;
           // UpdateAmmoCountUI();
            return true;
        }
        else
        {
            return false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
