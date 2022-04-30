﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCOneShotQuestManager : QuestManager
{
    [SerializeField]
    private Enums.OneShotQuestNPCs _npc;

    [SerializeField]
    private GameObject _reward;


    private bool _isActive = true;
    
    void Start()
    {
        EventManager.PlayerInteraction += HandlePlayerInteraction;
        UpdateScore();
    }

    protected void HandlePlayerInteraction(GameObject gameObject)
    {
        if (gameObject != this.gameObject || !_isActive)
            return;

        Inventory inv = FindObjectOfType<Inventory>();
        List<RecyclableObject.ObjID> keys = new List<RecyclableObject.ObjID>(inv.GetInventory.Keys);

        foreach (RecyclableObject.ObjID k in keys)
        {
            if (inv.GetInventory.TryGetValue(k, out int value))
            {
                int used = _quests.UpdateQuest(k, value);
                inv.UpdateInventory(k, used);
            }
        }

        UpdateScore();

        if (_quests.IsQuestComplete())
        {
            _isActive = false;
            _reward.SetActive(true);
            EventManager.FirePoints(CorrectPoints);
        }
    }
}
