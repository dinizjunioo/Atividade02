using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmunitionUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammunitionCountText;
    [SerializeField] private TextMeshProUGUI ammunitionTypeText;
    public void UpdatedAmmoCountUI(int newCount)
    {
        ammunitionCountText.text = newCount.ToString();

    }
}
