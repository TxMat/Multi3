using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    #region Singleton

    private static CharactersManager Instance { get; set; }
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

    private void Start()
    {
        
    }

    #endregion

    #region Global Members

    private List<Character> m_characters = new();

    public static List<Character> Characters => new(Instance.m_characters);

    #endregion
}
