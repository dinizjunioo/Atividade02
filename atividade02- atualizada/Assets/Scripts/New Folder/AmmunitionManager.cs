using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class AmmunitionManager : MonoBehaviour
{
    

    public static AmmunitionManager instance;

    //[SerializeField] private TextAlignment AmmunitionCountText;

    [SerializeField] private AmmunitionUi ammunitionUi;

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
            ammunitionUi.UpdatedAmmoCountUI(AmmunitionCounts[ammunitionTypes]);
           // UpdateAmmoCountUI();
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetAmmunitionCount(AmmunitionTypes ammunitionType)
    {
        int count = 0;

        if (AmmunitionCounts.TryGetValue(ammunitionType, out count))
        {
            Debug.Log($"Tenho agora {count} balas de {ammunitionType}");
            return count;
        }
        else
        {
            // Tipo de munição não encontrado, retorna 0
            return 0;
        }

    }
}
