using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private PlayerHud hud;
    private UIManager ui;
    Animator animP;

    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    private void GetReferences()
    {
        hud = GetComponent<PlayerHud>();
        ui = GetComponent<UIManager>();
        animP = GetComponent<Animator>();
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        hud.UpdateHealth(health, maxHealth);
    }

    public override void Die()
    {
        base.Die();
        ui.SetActiveHud(false);
    }
}
