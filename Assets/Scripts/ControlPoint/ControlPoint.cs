using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    #region Global Members

    [Header("Control Point")]
    [SerializeField] private SphereCollider m_sphereCollider;
    [SerializeField][Range(1f, 25f)] private float m_zoneRadius;

    #endregion

    #region Editor

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (m_sphereCollider == null) m_sphereCollider = GetComponent<SphereCollider>();

        if (m_sphereCollider != null)
        {
            m_sphereCollider.isTrigger = true;
            m_sphereCollider.radius = m_zoneRadius;
        }
    }
#endif

    #endregion

    #region Trigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterCollider charaCollider))
        {
            OnCharaEnter(charaCollider.Chara);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out CharacterCollider charaCollider))
        {
            OnCharaExit(charaCollider.Chara);
        }
    }

    #endregion

    #region Character Management

    private Dictionary<Team, List<Character>> m_currentCharactersDico = new();

    private void OnCharaEnter(Character character)
    {
        if (character.Team == Team.None
            || m_currentCharactersDico[character.Team].Contains(character)) return;

        m_currentCharactersDico[character.Team].Add(character);

        CheckControlPointState();
    }
    private void OnCharaExit(Character character)
    {
        if (character.Team == Team.None) return;

        m_currentCharactersDico[character.Team].Remove(character);

        CheckControlPointState();
    }

    #endregion

    #region State

    private Team m_currentTeam = Team.None;
    private int m_currentCharacterNumber = 0;


    private void CheckControlPointState()
    {
        int formerCharacterNumber = m_currentCharacterNumber;
        bool redTeamIn = false;
        bool blueTeamIn = false;

        // Red Team
        List<Character> charaList = m_currentCharactersDico[Team.RED];
        if (charaList != null)
        {
            m_currentCharacterNumber = charaList.Count;
            redTeamIn = charaList.Count > 0;
        }
        else
        {
            m_currentCharacterNumber = 0;
        }
        
        // Blue Team
        charaList = m_currentCharactersDico[Team.BLUE];
        if (charaList != null)
        {
            m_currentCharacterNumber += charaList.Count;
            blueTeamIn = charaList.Count > 0;
        }

        m_currentTeam = (m_currentCharacterNumber == 0 || (redTeamIn && blueTeamIn)) ? Team.None : redTeamIn ? Team.RED : Team.BLUE;

        if (formerCharacterNumber == 0 && m_currentTeam != Team.None)
        {
            OnBecameControlled();
        }
    }

    /// <summary>
    /// Called when a first player enters the Control Point
    /// </summary>
    private void OnBecameControlled()
    {

    }

    #endregion

    #region Points

    public (Team team, int points) GetPoints()
    {
        if (m_currentTeam == Team.None)
        {
            return (m_currentTeam, 0);
        }
        return (m_currentTeam, m_currentCharacterNumber);
    }

    #endregion
}
