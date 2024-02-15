using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    Bank bank;

    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    void AssertBank()
    {
        if(null == bank) {
            // Throw exception, etc.
        }
    }

    public void RewardGold()
    {
        AssertBank();
        bank.Deposit(goldReward);
    }
    
    public void StealGold()
    {
        AssertBank();
        bank.Withdraw(goldPenalty);
    }
}
