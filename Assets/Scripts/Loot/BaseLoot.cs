using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum LootType
{
    NONE = 0,
    HEAL = 1,
}

public abstract class BaseLoot : MonoBehaviour
{
    #region Global Members

    [Header("Base Loot")]
    [SerializeField] private SphereCollider m_sphereCollider;

    #endregion

    #region Public Accessors

    public abstract LootType Type { get; }

    #endregion

    #region Editor

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (m_sphereCollider == null) m_sphereCollider = GetComponent<SphereCollider>();

        if (m_sphereCollider != null) m_sphereCollider.isTrigger = true;
    }
#endif

    #endregion

    #region Trigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterCollider charaCollider))
        {
            TryGrabbedByPlayer(charaCollider.Chara);
        }
    }

    #endregion

    #region Behaviour

    private void TryGrabbedByPlayer(Character character)
    {
        if (character.CanGrabLoot(this))
        {
            character.GrabLoot(this);
            OnGrabbedByPlayer(character);
        }
    }

    protected virtual void OnGrabbedByPlayer(Character character)
    {
        // Disable Collider
        m_sphereCollider.enabled = false;

        // Destroy
        Destroy(gameObject);
    }

    #endregion
}
