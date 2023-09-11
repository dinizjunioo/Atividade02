using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Manual Gun", menuName = "Gun")]
public class Manual : Gun
{
    public override void OnMouseDown(Transform cameraPos)
    {
        RaycastHit whatIHit;
        if (Physics.Raycast(cameraPos.position, cameraPos.transform.forward,
            out whatIHit, Mathf.Infinity))
        {
            IDamageable damageable = whatIHit.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                // calculando o valor do dano pelo distancia
                float normalisedDistance = whatIHit.distance / maximumRange;
                if (normalisedDistance <= 1)
                    damageable.danoCausado(Mathf.RoundToInt(Mathf.Lerp(maximumDamage,
                        minimumDamage, normalisedDistance)));
            }
        }
    }
}
