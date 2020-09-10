
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, COMBAT, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerSpawn;
    public Transform enemySpawn;

    public double totalSpellDamage;

    public Transform cardPosition1;
    public Transform cardPosition2;
    public Transform cardPosition3;
    public Transform cardPosition4;
    public Transform cardPosition5;
    public Transform cardPosition6;
    public Transform cardPosition7;

    public GameObject card1;//the actual cards
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;
    public GameObject card5;
    public GameObject card6;
    public GameObject card7;
    public GameObject card8;
    public GameObject card9;
    public GameObject card10;
    public GameObject card11;

    public GameObject cardPosition1GO;
    public GameObject cardPosition2GO;
    public GameObject cardPosition3GO;
    public GameObject cardPosition4GO;
    public GameObject cardPosition5GO;
    public GameObject cardPosition6GO;
    public GameObject cardPosition7GO;

    public GameObject attackIntention;
    public GameObject defendIntention;

    public int manaCost;


    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public Deck deck;

    public GameObject playerArea;
    public GameObject enemyArea;
    public GameObject neutralArea;
    public GameObject discardPile;

    public Unit playerUnit;
    public Unit enemyUnit;

    public GameObject cardInHand;

    public List<GameObject> cards = new List<GameObject>();
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> cardPositions = new List<GameObject>();

    public int randomEnemyAction;

    public int enemyLevel;
    public int lifeMultiEvery10;
    public double amountOfLifeGained;

    public GameObject pack;

    public int totalMaxMana;

    //public Text dialogueText;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {

        enemyLevel = 1;
        state = BattleState.START;
        StartCoroutine(SetupBattle());

        //later on add the cards from the deck slot parents children aka deck slots to the list cards.Add(deck.deckSlot[i]); need to make puvlic deck and array list within deck
        cards.Add(card1);
        cards.Add(card2);
        cards.Add(card3);
        cards.Add(card4);
        cards.Add(card5);
        cards.Add(card6);
        cards.Add(card7);
        cards.Add(card8);
        cards.Add(card9);
        cards.Add(card10);
        cards.Add(card11);

        cardPositions.Add(cardPosition4GO);
        cardPositions.Add(cardPosition3GO);
        cardPositions.Add(cardPosition5GO);
        cardPositions.Add(cardPosition2GO);
        cardPositions.Add(cardPosition6GO);
        cardPositions.Add(cardPosition1GO);
        cardPositions.Add(cardPosition7GO);


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("u") && state == BattleState.WON)
        {
            Debug.Log("u was presed");
            state = BattleState.START;
            StartCoroutine(SetupBattle());
        }

        enemyHUD.SetLife(enemyUnit.currentLife);
        playerHUD.SetLife(playerUnit.currentLife);
        playerHUD.SetArmour(playerUnit);
        enemyHUD.SetArmour(enemyUnit);

        if (enemyUnit.isFrozen == true && randomEnemyAction == 0)
        {
            randomEnemyAction = Random.Range(1, 3);
            double totalEnemyDamage = enemyUnit.TotalEnemyDamageValue();
            enemyHUD.SetIntention(randomEnemyAction, totalEnemyDamage);
        }

        if (enemyUnit.hasThorns == true && randomEnemyAction == 1)
        {
            randomEnemyAction = 2;
            double totalEnemyDamage = enemyUnit.TotalEnemyDamageValue();
            enemyHUD.SetIntention(randomEnemyAction, totalEnemyDamage);
        }

        
    }

    IEnumerator SetupBattle()
    {
        DiscardHand();

        //LoadPlayer();
        if (playerSpawn.transform.childCount < 1)
        {
            GameObject playerGO = Instantiate(playerPrefab, playerSpawn);
            playerUnit = playerGO.GetComponent<Unit>();
        }

        GameObject enemyGO = Instantiate(enemyPrefab, enemySpawn);
        enemyUnit = enemyGO.GetComponent<Unit>();

        SetStatsOnStartup();



        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
        playerHUD.SetArmour(playerUnit);
        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        //damage the enemy
        enemyUnit.TakeDamage(1000000000);
        Draw(1);


        enemyHUD.SetLife(enemyUnit.currentLife);  //updates life bar


        yield return new WaitForSeconds(2f);

    }

    IEnumerator EnemyAttack()
    {
        //damage the enemy
        double totalEnemyDamage = enemyUnit.CalculateTotalDamage(playerUnit);
        playerUnit.TakeDamage(totalEnemyDamage);


        playerHUD.SetLife(playerUnit.currentLife); //updates life bar
        playerHUD.SetArmour(playerUnit);

        yield return new WaitForSeconds(2f);

        //check if enemy is dead 

        //change state based on what happened
        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }

    void PlayerTurn()
    {
        PlayerUpkeep();
        playerUnit.currentMana = totalMaxMana;
        playerHUD.SetMana(playerUnit.currentMana, totalMaxMana);
        //activate player and enemy areas:
        playerArea.SetActive(true);
        enemyArea.SetActive(true);
        neutralArea.SetActive(true);

        enemyUnit.isFrozen = false;

        //show enemy intent for the coming turn

        //draw five cards 
        Draw(5);

        randomEnemyAction = Random.Range(0, 3);


        //Debug.Log(randomEnemyAction);


        double totalEnemyDamage = enemyUnit.TotalEnemyDamageValue();
        enemyHUD.SetIntention(randomEnemyAction, totalEnemyDamage);
    }

    void EnemyTurn()
    {

        ResetStatsOnEnemyTurn();

        if (enemyUnit.isIgnited == true)
        {
            enemyUnit.TakeIgniteDamage(enemyUnit);
            Debug.Log("The Enemy did take ignite Damage");
        }



        //act on intent displayed to user, if it's attack for 40 then enemy will do that 
        //Debug.Log("Enemy Turn");
        if (randomEnemyAction == 0)
        {
            StartCoroutine(EnemyAttack());
        }
        if (randomEnemyAction == 1)
        {
            StartCoroutine(EnemyBuff());
        }
        if (randomEnemyAction == 2)
        {
            StartCoroutine(EnemyDefend());
        }

        playerHUD.SetArmour(playerUnit);

    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
        //StartCoroutine(EnemyAttack());
    }

    public void Draw(int drawNumber)
    {


        for (int i = 0; i < drawNumber; i++)
        {
            int randomNumber = Random.Range(0, cards.Count);  //selects a random card from a list of cards
            hand.Add(cards[randomNumber]);  //adds it to my hand i need to remove it after it is played
            //Debug.Log(randomNumber +  " Random number");
            for (int y = 0; y < cardPositions.Count; y++)
            {




                if (cardPositions[y].transform.childCount < 2)
                {

                    cardInHand = Instantiate(hand[hand.Count - 1], cardPositions[y].transform); //this grabs the card that was most recently added to your hand from your library 
                    break;

                }
                else
                {
                    //Debug.Log(hand[i]);
                }
            }
            //Debug.Log(randomNumber);





        }



    }

    public void PlayerCastsSpell(GameObject cardBeingCast)
    {

        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        GameObject card = cardBeingCast.transform.GetChild(1).gameObject;
        CardStats cardStats = card.GetComponent<CardStats>();
        manaCost = cardStats.baseManaCost;
        if (cardStats.cardType == "aura")
        {
            PlayerCastsAura(cardBeingCast);
        }

        if (cardStats.cardType == "defense")
        {
            PlayerCastsDefense(cardBeingCast);
        }

        if (cardStats.name == "Shatter" && enemyUnit.isFrozen != true)//checks to see if enemy is frozen to be able to cast shatter
        {
            return;
        }

        if (cardStats.cardType == "spell" && playerUnit.isFrozen == true)
        {
            return;
        }

        if (cardStats.cardType == "spell")
        {
            //Debug.Log("Spell! " + cardStats.cardType);

            if (manaCost <= playerUnit.currentMana)
            {
                DiscardCard(card);
                playerUnit.currentMana = playerUnit.currentMana - manaCost;
                playerHUD.SetMana(playerUnit.currentMana, totalMaxMana);
                if (playerUnit.arcaneLibrary == true)
                {
                    Draw(1);
                }

                for (int i = 0; i < cardStats.baseNumOfAttacks; i++)//for loop for the number of uses a card has
                {


                    totalSpellDamage = cardStats.CalculatedTotalSpellDamage(playerUnit, enemyUnit);
                    enemyUnit.TakeDamageSpell(cardBeingCast, totalSpellDamage);

                    if (cardStats.baseArmour != 0) //adds armour to player if spell says deal 5 gain five armour or something along those lines
                    {
                        double totalArmourGained = cardStats.CalculateArmour(playerUnit, enemyUnit);
                        playerUnit.GainArmour(totalArmourGained);
                        playerHUD.SetArmour(playerUnit);
                    }

                    if (enemyUnit.hasThorns == true)
                    {
                        playerUnit.TakeThornDamage(1, playerUnit);
                        playerHUD.SetArmour(playerUnit);
                    }



                }

            } //checks to see if player has enough mana

            



            enemyHUD.SetLife(enemyUnit.currentLife);  //updates life bar


        }



        enemyHUD.SetArmour(enemyUnit);

    }

    public void PlayerCastsAura(GameObject cardBeingCast)
    {

        GameObject card = cardBeingCast.transform.GetChild(1).gameObject;
        CardStats cardStats = card.GetComponent<CardStats>();
        manaCost = cardStats.baseManaCost;
        if (manaCost <= playerUnit.currentMana)
        {
            Debug.Log("Casting Aura " + cardBeingCast);
            Debug.Log("Mana Cost " + manaCost);
            playerUnit.currentMana = playerUnit.currentMana - manaCost;
            playerHUD.SetMana(playerUnit.currentMana, totalMaxMana);
            DiscardCard(card);
            if (cardStats.name == "Arcane Library")
            {
                playerUnit.arcaneLibrary = true;
            }
        }


    }

    public void PlayerCastsDefense(GameObject cardBeingCast)
    {
        GameObject card = cardBeingCast.transform.GetChild(1).gameObject;
        CardStats cardStats = card.GetComponent<CardStats>();
        manaCost = cardStats.baseManaCost;
        if (manaCost <= playerUnit.currentMana)
        {

            playerUnit.currentMana = playerUnit.currentMana - manaCost;
            playerHUD.SetMana(playerUnit.currentMana, totalMaxMana);
            double totalArmourGained = cardStats.CalculateArmour(playerUnit, enemyUnit);
            playerUnit.GainArmour(totalArmourGained);
            playerHUD.SetArmour(playerUnit);
            DiscardCard(card);
        }
    }


    public void DiscardCard(GameObject cardBeingCast)
    {
        Destroy(cardBeingCast);
    }

    public void DiscardHand()
    {
        for (int i = 0; i < cardPositions.Count; i++)
        {
            if (cardPositions[i].transform.childCount > 1)
            {
                Destroy(cardPositions[i].transform.GetChild(1).gameObject);
            }

        }
        hand.Clear();
    }


    public void EndTurn()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        DiscardHand();
        state = BattleState.ENEMYTURN;
        EnemyTurn();
    }


    IEnumerator EnemyDefend()
    {
        //int RandomDefense = Random.Range(0, 2); //i dont know how i feel about lifegain 

        int RandomDefense = 1;
        if (RandomDefense == 0)
        {
            enemyUnit.maxLife = enemyUnit.maxLife + amountOfLifeGained;
            enemyUnit.currentLife = enemyUnit.currentLife + amountOfLifeGained;
            Debug.Log("Gain Life");
        }

        if (RandomDefense == 1)
        {

            enemyUnit.GainArmour(amountOfLifeGained);
            enemyHUD.SetArmour(enemyUnit);
        }
        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }


    IEnumerator EnemyBuff()
    {
        enemyUnit.hasThorns = true;
        enemyUnit.numOfThorns = 2;
        Debug.Log(enemyUnit.numOfThorns + " Number of thorns ");
        Debug.Log(enemyUnit.numOfThorns + " Activated Thorns ");

        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }


    IEnumerator EnemyCastCurse()
    {
        Debug.Log("Cast Curse");
        int randomAilment = Random.Range(0, 3);

        if (randomAilment == 0)
        {
            FreezeUnit(playerUnit);
        }
        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }



    public void Won()
    {
        playerArea.SetActive(false);
        enemyArea.SetActive(false);
        neutralArea.SetActive(false);
        //playerUnit.unitLevel = 1;
        //SavePlayerStats();
        //Debug.Log("Won " + state);
        enemyHUD.SetLife(0);
        enemyLevel++;
        DiscardHand();
        //pack.SetActive(true);
    }

    public void SavePlayerStats()
    {
        SaveSystem.SavePlayer(playerUnit);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        playerUnit.unitLevel = data.unitLevel;
        playerUnit.maxLife = data.maxLife;
    }

    public void FreezeUnit(Unit unit)
    {
        unit.isFrozen = true;
        Debug.Log(unit + "frozen " + unit.isFrozen);
    }

    public void ResetStatsOnEnemyTurn() //used at beginning of enemy turn
    {
        enemyUnit.ResetArmour();
        attackIntention.SetActive(false);
        defendIntention.SetActive(false);
        if (enemyUnit.numOfThorns <= 0)
        {
            enemyUnit.hasThorns = false;
        }
        else
        {
            enemyUnit.numOfThorns--;
            Debug.Log(enemyUnit.numOfThorns + " Number of Thorns");
        }
        playerUnit.isFrozen = false;
        playerArea.SetActive(false);
        enemyArea.SetActive(false);
        neutralArea.SetActive(false);
        playerUnit.isFrozen = false;
        enemyUnit.isShocked = false;
        
    }

    public void SetStatsOnStartup()
    {
        playerUnit.arcaneLibrary = false;
        totalMaxMana = playerUnit.maximumMana + (int)playerUnit.maxMana.GetValue();
        playerUnit.currentMana = totalMaxMana;
        playerHUD.SetMana(playerUnit.currentMana, totalMaxMana);
        enemyUnit.hasDied = false;
        enemyUnit.unitLevel = enemyLevel;
        lifeMultiEvery10 = ((int)enemyLevel / 10) + 1;
        enemyUnit.maxLife = (lifeMultiEvery10) * 40;
        enemyUnit.currentLife = enemyUnit.maxLife;
        amountOfLifeGained = enemyUnit.maxLife / 4;
        playerUnit.currentLife = playerUnit.maxLife;
        playerUnit.currentArmour = 0;
        enemyUnit.isShocked = false;
        attackIntention.SetActive(false);
        defendIntention.SetActive(false);
    }

    public void PlayerUpkeep()
    {
        playerUnit.ResetArmour();
    }
}
