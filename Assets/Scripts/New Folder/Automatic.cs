using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Automatic Gun", menuName = "Gun/Automatic")]
public class Automatic : Gun
{
    public float fireRate;
    private float lastTimeFired;
    public override void OnMouseHold(Transform cameraPos)
    {
        if(Time.time - lastTimeFired > 1 / fireRate)
        {
            lastTimeFired = Time.time;
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
}
