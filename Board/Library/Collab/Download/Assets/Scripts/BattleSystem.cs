
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
    

    public Transform cardPosition1;
    public Transform cardPosition2;
    public Transform cardPosition3;
    public Transform cardPosition4;
    public Transform cardPosition5;
    public Transform cardPosition6;
    public Transform cardPosition7;

    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;
    public GameObject card5;
    public GameObject card6;
    public GameObject card7;
    

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public Deck deck;

    public GameObject playerArea;
    public GameObject enemyArea;
    public GameObject neutralArea;

    Unit playerUnit;
    Unit enemyUnit;

    public List<GameObject> cards = new List<GameObject>();

    //public Text dialogueText;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerSpawn);
        playerUnit = playerGO.GetComponent<Unit>();


        GameObject enemyGO = Instantiate(enemyPrefab, enemySpawn);
        enemyUnit = enemyGO.GetComponent<Unit>();

        //dialogueText.text = enemyUnit.unitName;

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        //damage the enemy
        enemyUnit.TakeDamage(playerUnit.CalculateTotalDamage(enemyUnit));

        

        enemyHUD.SetLife(enemyUnit.currentLife);  //updates life bar


        yield return new WaitForSeconds(2f);

        //check if enemy is dead 

        //change state based on what happened


    }

    IEnumerator EnemyAttack()
    {
        //damage the enemy
        playerUnit.TakeDamage(enemyUnit.physicalDamage.GetValue());


        playerHUD.SetLife(playerUnit.currentLife); //updates life bar


        yield return new WaitForSeconds(2f);

        //check if enemy is dead 

        //change state based on what happened


    }

    void PlayerTurn()
    {

        playerHUD.SetMana(playerUnit.currentMana, playerUnit.maximumMana);
        //activate player and enemy areas:
        playerArea.SetActive(!playerArea.activeSelf);
        enemyArea.SetActive(!enemyArea.activeSelf);
        neutralArea.SetActive(!neutralArea.activeSelf);
        //gain 3 mana

        //show enemy intent for the coming turn

        //draw five cards 
        Draw(5);

        //check to see if player plays cards

        //damage and resolutions

        //end turn

    }

    void EnemyTurn()
    {
        //act on intent displayed to user, if it's attack for 40 then enemy will do that 
    }

    public void OnAttackButton()
    {
        if(state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
        StartCoroutine(EnemyAttack());
    }

    public void Draw(int drawNumber)
    {
        //later use a for loop to draw x where x is draw number

        //GameObject skillCard = Instantiate(cards[Random.Range(0, cards.Count)], cardPosition1);
        GameObject skillCard = Instantiate(cards[Random.Range(0, cards.Count)], cardPosition2);
        skillCard = Instantiate(cards[Random.Range(0, cards.Count)], cardPosition3);
        skillCard = Instantiate(cards[Random.Range(0, cards.Count)], cardPosition4);
        skillCard = Instantiate(cards[Random.Range(0, cards.Count)], cardPosition5);
        skillCard = Instantiate(cards[Random.Range(0, cards.Count)], cardPosition6);
        //skillCard = Instantiate(cards[Random.Range(0, cards.Count)], cardPosition7);


    }

    public void PlayerCastsSpell(GameObject cardBeingCast)
    {
       

        GameObject card = cardBeingCast.transform.GetChild(1).gameObject;
        CardStats cardStats = card.GetComponent<CardStats>();
        int manaCost = cardStats.baseManaCost; //later i can change this to total mana cost 
       

        if (manaCost <= playerUnit.currentMana)
        {
            playerUnit.currentMana = playerUnit.currentMana - manaCost;
            enemyUnit.TakeDamageSpell(playerUnit.physicalDamage.GetValue(), cardBeingCast);

            playerHUD.SetMana(playerUnit.currentMana, playerUnit.maximumMana);
        }
        

    }
}
