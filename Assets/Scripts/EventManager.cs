using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameEvent
{
    None = 0,
    START_LEVEL = 1,
    COMPLETE_LEVEL = 2,
    GAME_OVER = 3,
}

public static class EventManager
{
    private static Dictionary<GameEvent, Action> m_eventDico = new();


    public static void StartListening(GameEvent keyEvent, Action listener)
    {
        if (m_eventDico.ContainsKey(keyEvent))
        {
            m_eventDico[keyEvent] += listener;
        }
        else
        {
            m_eventDico.Add(keyEvent, listener);
        }
    }

    public static void StopListening(GameEvent keyEvent, Action listener)
    {
        if (m_eventDico.ContainsKey(keyEvent))
        {
            m_eventDico[keyEvent] -= listener;
        }
    }

    public static void TriggerEvent(GameEvent keyEvent)
    {
        if (m_eventDico.TryGetValue(keyEvent, out Action thisEvent))
        {
            thisEvent?.Invoke();
        }
    }
}
