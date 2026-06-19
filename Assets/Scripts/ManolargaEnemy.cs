using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;


public class ManolargaEnemy : MonoBehaviour
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
    GameObject target;
    public float radiusattack = 1;
    public float radiusMovement = 2.5f;
    public float RadiusFlee = 5f;
    

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

        if (target == null)
        {
            return;
        }
        Vector3 targetPos = target.transform.position;
        Vector3 myPos = transform.position;
        switch (state)
        {
            case EnemyState.None:
                state = EnemyState.Idle;
                break;

            case EnemyState.Idle:
                {

                    if (Vector3.Distance(targetPos, myPos) <= RadiusFlee)
                        state = EnemyState.Flee;

                    if (Vector3.Distance(targetPos, myPos) <= radiusMovement)
                        state = EnemyState.Chase;
                }
                break;

            case EnemyState.Chase:
                {
                    Vector3 direction = (targetPos - myPos).normalized;
                    transform.position += direction * Speed * Time.deltaTime;

                    
                    if (Vector3.Distance(targetPos, myPos) > radiusMovement)
                        state = EnemyState.Flee;
                    
                    if (Vector3.Distance(targetPos, myPos) < radiusattack)
                        state = EnemyState.Attack;
                }
                break;

            case EnemyState.Flee:
                {
                   if (Vector3.Distance(targetPos, myPos) < RadiusFlee)
                    {
                        Vector3 direction = (targetPos - myPos).normalized;
                        transform.position -= direction * Speed * Time.deltaTime;
                    }

                    if (Vector3.Distance(targetPos, myPos) > RadiusFlee)
                    {
                        state = EnemyState.Idle;
                    }

                    if (Vector3.Distance(targetPos, myPos) < radiusMovement)
                    {
                        state = EnemyState.Chase;
                    }
                        
                    if (Vector3.Distance(targetPos,myPos) < RadiusFlee && Vector3.Distance(targetPos,myPos) > radiusMovement)
                    {
                        state = EnemyState.Attack;
                    }
                }
                break;

            case EnemyState.Attack:
                {
                    if (Vector3.Distance(targetPos, myPos) < radiusattack)
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
                    }


                    SpecialabilityReset += Time.deltaTime;
                    if (SpecialabilityReset >= MaxAbilityTime)
                    {

                        IsAbleToUseSpecialAbility = true;

                        SpecialabilityReset = 0;
                    }

                    if ( IsAbleToUseSpecialAbility == true)
                    {
                        SpecialabilityReset += Time.deltaTime;
                        if (SpecialabilityReset >= MaxAbilityTime)
                        {

                            IsAbleToUseSpecialAbility = true;

                            SpecialabilityReset = 0;
                        }

                            target.GetComponent<Player>().Health -= SpecialAbilityDamage;
                            IsAbleToUseSpecialAbility = false;
                            Debug.Log("toma toma te pego piu piu");
                        
                                
                    }

                    if (Vector3.Distance(targetPos, myPos) > radiusattack)
                        state = EnemyState.Flee;
                }
                break;

            default:
                break;
        }




    }

    
}