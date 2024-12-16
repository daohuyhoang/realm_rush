using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField]int currentBalance;
    [SerializeField] TMP_Text balanceText;
    
    public int CurrentBalance { get => currentBalance;}

    void Awake()
    {
        currentBalance = startingBalance;
        UpdateBalance();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateBalance();
    }
    
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateBalance();
        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }
    void UpdateBalance()
    {
        balanceText.text = "Gold: " + currentBalance;   
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
