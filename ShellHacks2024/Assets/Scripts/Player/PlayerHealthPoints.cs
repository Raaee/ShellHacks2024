using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using UnityEngine.Events;


public class PlayerHealthPoints : HealthPoints
{
    // Start is called before the first frame update
   /* public override void Start()
    {
        base.Start();  
    }
*/
    // Update is called once per frame
    [ProButton]
    public override void Die()
    {
        OnHealthChange?.Invoke();
        OnDead?.Invoke();
        Destroy(this.gameObject);
    }

    public override void ResetHealth()
    {
        base.ResetHealth();
    }
}
