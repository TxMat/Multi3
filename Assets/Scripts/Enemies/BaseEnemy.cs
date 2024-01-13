using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemy : MonoBehaviour
{
    public class Target
    {
        public Target(Character _character, Vector3 _position)
        {
            character = _character;
            position = _position;
        }

        public Character character;
        public Vector3 position;
    }

    #region Global Members

    [Header("Base Enemy")]
    [SerializeField] protected NavMeshAgent m_agent;


    public bool IsActive { get; protected set; }

    #endregion

    #region Core Behaviour

    public void UpdateEnemy()
    {
        UpdateDestination();
    }

    #endregion

    #region Movements

    private Vector3 m_currentDestination;
    private bool m_updateDestination;
    protected void SetDestination(Vector3 destination)
    {
        m_updateDestination = m_currentDestination != destination;
        m_currentDestination = destination;
    }

    private void UpdateDestination()
    {
        if (m_updateDestination)
        {
            m_agent.destination = m_currentDestination;
        }
    }

    #endregion

    #region Target

    protected Target CurrentTarget { get; private set; } = null;

    public void ResetTarget()
    {
        CurrentTarget = null;
    }
    public void AnalyzePotentialTarget(Target target)
    {
        if (CanTarget(target))
        {
            CurrentTarget = target;
        }
    }
    protected abstract bool CanTarget(Target target);

    #endregion
}
