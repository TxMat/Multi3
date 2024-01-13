using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameMode
{
    NONE = 0,
    PVE = 1,
    PVP = 2,
}

public enum PVPMode
{
    NONE = 0,
    MG = 1,
    MME = 2,
    PDC = 3,
}

public static class GameManager
{
    #region Game Parameters

    private static GameMode m_gameMode;
    public static GameMode Mode => m_gameMode;


    private static PVPMode m_pvpMode;
    public static PVPMode PVPMode => m_pvpMode;


    private static int m_currentLevel = 1;
    public static int CurrentLevel => m_currentLevel;


    private static bool m_isPlaying = false;
    public static bool IsPlaying => m_isPlaying;

    #endregion
}
