using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;


public class SpecialEnemy : MonoBehaviour
{
    public enum EnemyState
    {
        None,
        Idle,
        Chase,
        Flee,
        Attack,
        
    }
    public EnemyState state;
    
    public float Speed = 5;
    public GameObject target;
    public float radiusattack = 1;
    public float radiusMovement = 5;
    public bool AttackMode = false;


    public float timeToChangeMode = 5;
    public float currentTime = 0;

    public bool IsAbleToAttack = true;
    public float MaxTime = 2;
    public float damage = 5;
    public float ResetTime = 0;

    public bool IsAbleToUseSpecialAbility = true;
    public float SpecialabilityReset = 0;
    public float MaxAbilityTime = 4;
    public float SpecialAbilityDamage = 20;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {



        Vector3 targetPos = target.transform.position;
        Vector3 myPos = transform.position;
        switch (state)
        {
            case EnemyState.None:
                break;

            case EnemyState.Idle:
                {
                    if (Vector3.Distance(targetPos, myPos) < radiusMovement)
                        state = EnemyState.Chase;
                }
                break;

            case EnemyState.Chase:
                {
                    Vector3 direction = (targetPos - myPos).normalized;
                    transform.position += direction * Speed * Time.deltaTime;

                    
                    if (Vector3.Distance(targetPos, myPos) > radiusMovement)
                        state = EnemyState.Idle;
                    
                    if (Vector3.Distance(targetPos, myPos) < radiusattack)
                        state = EnemyState.Attack;
                }
                break;

            case EnemyState.Flee:
                {

                }
                break;

            case EnemyState.Attack:
                {
                    if (IsAbleToAttack)
                    {
                        
                        Debug.Log("Atacando");
                        target.GetComponent<Player>().Health -= damage;
                        IsAbleToAttack = false;
                    }
                    currentTime += Time.deltaTime;
                    if (currentTime >= MaxTime)
                    {
                        IsAbleToAttack = true;

                        currentTime = 0;
                    }

                    
                    if (Vector3.Distance(targetPos, myPos) > radiusattack)
                        state = EnemyState.Chase;
                }
                break;

            default:
                break;
        }




    }

    public void ChangeMode()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeToChangeMode)
        {
            AttackMode = !AttackMode;
            currentTime = 0;
        }
        if (AttackMode == false)
        {
            FollowTarget(radiusMovement);
            if (!IsAbleToAttack)
                TimeToDoSet();


        }
        else
        {
            AvoidTarget(radiusattack);
            if (!IsAbleToUseSpecialAbility)
                TimeToDoSpeciaAbility();
        }

    }

    public void FollowTarget(float radiusMovement)
    {
        if (target == null)
        {
            return;
        }
        radiusMovement = 10;
        Vector3 direction = (target.transform.position - transform.position).normalized;
        if (Vector3.Distance(transform.position, target.transform.position) < radiusMovement)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < radiusattack)
            {
                Debug.Log("ven maldito");
                if (IsAbleToAttack)
                {
                    target.GetComponent<Player>().Health -= damage;
                    IsAbleToAttack = false;
                    Debug.Log("toma toma");
                }

            }
            else
            {
                transform.position += direction * Speed * Time.deltaTime;
            }
        }

    }
    public void AvoidTarget(float radiusattack)
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = (target.transform.position - transform.position).normalized;

        if (Vector3.Distance(transform.position, target.transform.position) < radiusMovement)
        {
            transform.position += -dir * Speed * Time.deltaTime;
       
            
        }
        else
        {
            if (radiusattack == 5)
            {
                if (IsAbleToUseSpecialAbility)
                {
                    target.GetComponent<Player>().Health -= SpecialAbilityDamage;
                    IsAbleToUseSpecialAbility = false;
                    Debug.Log("toma toma te pego piu piu");
                }
            }
           
        }

    }
    public void TimeToDoSet()
    {
        ResetTime += Time.deltaTime;
        if (ResetTime >= MaxTime)
        {

            IsAbleToAttack = true;

            ResetTime = 0;
        }
    }

    public void TimeToDoSpeciaAbility()
    {
        SpecialabilityReset += Time.deltaTime;
        if (SpecialabilityReset >= MaxAbilityTime)
        {

            IsAbleToUseSpecialAbility = true;

            SpecialabilityReset = 0;
        }
    }
}