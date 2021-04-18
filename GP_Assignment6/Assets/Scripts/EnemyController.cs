using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;

    public float refreshDelay = 1.0f;

    public ThirdPersonCharacter character;

    private void Start()
    {
        agent.updateRotation = false;
        StartCoroutine(RefreshTargetLocation());
    }

    void Update()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else character.Move(Vector3.zero, false, false);
    }

    public IEnumerator RefreshTargetLocation()
    {
        yield return new WaitForSeconds(refreshDelay);

        agent.SetDestination(FindObjectOfType<PlayerController>().gameObject.transform.position);

        StartCoroutine(RefreshTargetLocation());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
