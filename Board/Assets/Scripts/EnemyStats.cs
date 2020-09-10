using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Unit
{

    public SpawnRandomItem spawnRandomItem;
    public BattleSystem battleSystem;

    public override void Die()
    {
        base.Die();

        //death animation 


        //Destroy(gameObject);
        //destroy
        if (hasDied == false)
        {
            battleSystem.state = BattleState.WON;
            battleSystem.Won();
            Destroy(gameObject);
            spawnRandomItem.SpawnRandomEquipment(this.unitLevel);
            
            hasDied = true;
        }
        
    }
    
    void Start()
    {
        battleSystem = GameObject.FindGameObjectWithTag("Battle System").GetComponent<BattleSystem>();
        spawnRandomItem = gameObject.GetComponent<SpawnRandomItem>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
