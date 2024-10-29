using EditorAttributes;
using UnityEngine;
using UnityEngine.AI;
using UnityExtended.AI.Extensions;

/// <summary>
/// Set persistant target for a <see cref="NavMeshAgent"/>.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class SetTarget : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]
    [Required]
    private Transform target;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        agent.destination = target.position;

        Debug.Log(agent.IsAtDestination(target.position));
    }
}
