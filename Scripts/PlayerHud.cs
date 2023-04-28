using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    public static PlayerHud instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [SerializeField] private ProgressBar healthBar;
    [SerializeField] private WaveNumUpdater WaveUI;


    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        healthBar.SetValues(currentHealth, maxHealth);
    }

    public void UpdateWaveAmount()
    {
        WaveUI.addToWaveNUM();
    }

}
