using UnityEngine;
using UnityEngine.AI;

namespace UnityExtended.AI.Extensions {
    public static class NavMeshExtensions {
        /// <summary>
        /// Samples given position to the agent's navmesh and determines whether the agent achieved destination.
        /// </summary>
        /// <param name="agent">Agent.</param>
        /// <param name="position">Position of destination. Will get sampled to the navmesh with agent's type.</param>
        /// <param name="samplingDistance">Distance from the <paramref name="position"/> for the sampling.</param>
        /// <param name="areaMask">A bitmask representing the traversable area types.</param>
        /// <returns></returns>
        public static bool IsAtDestination(this NavMeshAgent agent, Vector3 position, float samplingDistance = 5, int areaMask = -1) {
            // sample point
            NavMeshQueryFilter filter = new() { agentTypeID = agent.agentTypeID, areaMask = areaMask };

            if (NavMesh.SamplePosition(position, out NavMeshHit hit, samplingDistance, filter)) {
                Vector3 sampledPos = hit.position;

                return agent.destination == sampledPos && agent.remainingDistance <= agent.stoppingDistance && !agent.IsMoving();
            }

            return false;
        }

        public static bool IsMoving(this NavMeshAgent agent) {
            return agent.velocity.sqrMagnitude > 0;
        }
    }
}
