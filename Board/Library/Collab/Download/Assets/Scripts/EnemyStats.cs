using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Unit
{

    public bool hasDied = false;
    public SpawnRandomItem spawnRandomItem;

    public override void Die()
    {
        base.Die();

        //death animation 


        //Destroy(gameObject);
        //destroy
        if (hasDied == false)
        {
            Destroy(gameObject);
            spawnRandomItem.SpawnRandomEquipment(this.level);
            
            hasDied = true;
        }
        
    }
    
    void Start()
    {
        spawnRandomItem = gameObject.GetComponent<SpawnRandomItem>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
