using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    public GameObject rougePrefab;
    public GameObject magePrefab;
    public GameObject knightPrefab;
    public GameObject barbarianPrefab;
    public GameObject EnemyPrefab;
    public Transform rougeBattlePosistion;
    public Transform mageBattlePosistion;
    public Transform knightBattlePosistion;
    public Transform barbarianBattlePosistion;
    public Transform enemyBattlePosistion;

    Unit RougeUnit;
    //unit MageUnit;
    //unit KnightUnit;
    //unit BarbarianUnit;
    Unit enemyUnit;
    Unit playerUnit;

    public BattleHUD rougeHUD;
    public BattleHUD mageHUD;
    public BattleHUD knightHUD;
    public BattleHUD barbarianHUD;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        //SetupBattle();
    }

    void SetupBattle()
    {
        //GameObject RougeGO = Instantiate(rougePrefab, rougeBattlePosistion);
        //GameObject MageGO = Instantiate(magePrefab, mageBattlePosistion);
        //GameObject KnightGO = Instantiate(knightPrefab, knightBattlePosistion);
        //GameObject BarbarianGO = Instantiate(barbarianPrefab, barbarianBattlePosistion);
        //RougeGO.Getcomponent<Unit>();
        //MageGO.Getcomponent<Unit>();
        //KnightGO.Getcomponent<Unit>();
        //BarbarianGO.Getcomponent<Unit>();
        //GameObject EnemyGO =Instantiate(EnemyPrefab, enemyBattlePosistion);
        //EnemyGO.Getcomponent<Unit>();
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        playerUnit = RougeUnit;
        enemyUnit.currHP -= RougeUnit.attack;
        bool isDead = enemyUnit.currHP= 0b0;
        yield return new WaitForSeconds(2f);
        if(isDead)
        {
            state = BattleState.WON;
        }else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
       
    }
    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void EnemyTurn()
    {

    }
    void PlayerTurn()
    {

    }
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerAttack());
    }
}
