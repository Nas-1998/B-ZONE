using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveNumUpdater : MonoBehaviour
{
    public int WaveAdder;
    public int currentWaveNUM;
    [SerializeField] private Text WaveAmount;

    private void Start()
    {
        InitVariables();
    }

    private void  InitVariables()
    {
        currentWaveNUM = 1;
    }

    public void addToWaveNUM()
    {
        currentWaveNUM += WaveAdder;
        WaveAmount.text = currentWaveNUM.ToString();
    }
}
