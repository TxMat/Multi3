using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    #region Global Members

    [Header("Character Collider")]
    [SerializeField] private Character m_character;

    #endregion

    #region Public Accessors

    public Character Chara => m_character;

    #endregion
}
