using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    #region Singleton

    private static EnemiesManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        Init();
    }

    #endregion

    #region Core Behaviour

    private void Init()
    {

    }

    private void Update()
    {
        if (GameManager.IsPlaying)
        {
            UpdateEnemiesTargets();
            UpdateEnemies();
        }
    }

    #endregion

    #region Enemies Registration

    private List<BaseEnemy> m_enemies = new();

    public static void Register(BaseEnemy enemy)
    {
        if (enemy != null && !Instance.m_enemies.Contains(enemy))
        {
            Instance.m_enemies.Add(enemy);
        }
    }
    public static void Unregister(BaseEnemy enemy)
    {
        if (enemy != null && Instance.m_enemies.Contains(enemy))
        {
            Instance.m_enemies.Remove(enemy);
        }
    }

    #endregion

    #region Enemies Target

    private void UpdateEnemiesTargets()
    {
        List<Character> characters = CharactersManager.Characters;

        foreach (var enemy in m_enemies.Where(e => e.IsActive))
        {
            foreach (var character in characters)
            {
                enemy.AnalyzePotentialTarget(new BaseEnemy.Target(character, character.CurrentPosition));
            }
        }
    }

    #endregion

    #region Enemies Update

    private void UpdateEnemies()
    {
        foreach (var enemy in m_enemies.Where(e => e.IsActive))
        {
            enemy.UpdateEnemy();
        }
    }

    #endregion
}
