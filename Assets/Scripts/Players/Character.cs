using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Team
{
    None = 0,
    RED = 1,
    BLUE = 2,
}

public class Character : MonoBehaviour
{
    #region Global Members

    private Team m_team;

    public Team Team => m_team;


    public Vector3 CurrentPosition { get; protected set; }

    #endregion

    #region Core Behaviour

    private void OnEnable()
    {
        EventManager.StartListening(GameEvent.START_LEVEL, OnStartLevel);
        EventManager.StartListening(GameEvent.COMPLETE_LEVEL, OnCompleteLevel);
        EventManager.StartListening(GameEvent.GAME_OVER, OnGameOver);
    }
    private void OnDisable()
    {
        EventManager.StopListening(GameEvent.START_LEVEL, OnStartLevel);
        EventManager.StopListening(GameEvent.COMPLETE_LEVEL, OnCompleteLevel);
        EventManager.StopListening(GameEvent.GAME_OVER, OnGameOver);
    }

    #endregion

    #region Events

    private void OnStartLevel()
    {

    }
    private void OnCompleteLevel()
    {

    }
    private void OnGameOver()
    {

    }

    #endregion

    #region Loot

    public virtual bool CanGrabLoot(BaseLoot loot)
    {
        switch (loot.Type)
        {
            case LootType.NONE:
                return false;
        }
        return false;
    }

    public virtual void GrabLoot(BaseLoot loot)
    {
        if (loot == null) return;

        switch (loot.Type)
        {
            case LootType.NONE:
                break;
        }
    }

    #endregion
}
