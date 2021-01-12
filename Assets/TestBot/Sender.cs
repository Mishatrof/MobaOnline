using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sender : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent navAgent;
    public Animator animator;

    float distance;
    float angleToTarget;
    Vector3 vecToTarget;

    float cooldownAttack;
    int cachedState;

    const int die = 20298039;
    const int walk =    765711723;
    const int idle =    2081823275;

    void Start()
    {
        cachedState = animator.GetCurrentAnimatorStateInfo(0).shortNameHash;
    }

    void Update()
    {
        var stateInfo = animator.GetCurrentAnimatorStateInfo(0);


        if (stateInfo.shortNameHash != cachedState)
        {
            OnExit(cachedState);
            OnEnter(stateInfo.shortNameHash);
            cachedState = stateInfo.shortNameHash;
            return;
        }

        switch(stateInfo.shortNameHash)
        {
            case die:
                if (stateInfo.normalizedTime * stateInfo.length > 5f)
                    animator.SetTrigger("resurrection");
                break;

            case walk:
                AgentUpdate();
                AttackUpdate();

                if (navAgent.velocity == Vector3.zero)
                    LookAtTaget();
                break;

            case idle:
                AgentUpdate();
                AttackUpdate();
                break;
        }
    }

    float lastTime;

    void OnEnter(int exitState)
    {
        switch(exitState)
        {
            case die:
                lastTime = Time.time;
                navAgent.enabled = false;
                break;
        }
    }

    void OnExit(int enterState)
    {
        switch (enterState)
        {
            case die:
                print(Time.time - lastTime);
                navAgent.enabled = true;
                break;
        }
    }

    void LookAtTaget()
    {
        //var vector = new Vector3(vecToTarget.x, 0f, vecToTarget.z);
        var goalRotation = Quaternion.LookRotation(vecToTarget, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, navAgent.angularSpeed * Time.deltaTime);
    }

    void AgentUpdate()
    {
        if (distance > 2f)
        {
            navAgent.SetDestination(target.position);
        }
    }

    void AttackUpdate()
    {
        if (distance > 2f)
            return;

        if (cooldownAttack <= 0f)
        {

            if (angleToTarget < 35f)
            {
                animator.SetTrigger("attack");
                cooldownAttack = 1f;
            }
        }
        else
        {
            cooldownAttack -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        vecToTarget = target.position - transform.position;
        distance = vecToTarget.magnitude;

        vecToTarget.y = 0f;
        angleToTarget = Vector3.Angle(vecToTarget, transform.forward);

        animator.SetBool("walk", navAgent.velocity != Vector3.zero || angleToTarget > 35f);
    }
}
