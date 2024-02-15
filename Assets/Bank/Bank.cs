using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI uiBalance;

    public int CurrentAmount { get {return currentBalance;}}

    public void Awake()
    {
        currentBalance = startingBalance;
        ReloadUI();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        ReloadUI();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        if(currentBalance < 0)
        {
            ReloadScene();
        }
        ReloadUI();
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    private void ReloadUI()
    {
        uiBalance.text = "Gold: " + currentBalance.ToString();
    }
}
