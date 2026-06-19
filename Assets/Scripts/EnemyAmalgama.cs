using UnityEngine;

public class EnemyAmalgama : MonoBehaviour
{

    public enum EnemyState
    {
        None,
        Idle,
        Chase,
        Attack,

    }
    public EnemyState State;
    public float Speed = 2.5f;
    public GameObject target;
    public float radiusattack = 1;
    public float radiusMovement = 5;

    public bool IsAbleToAttack = true;
    public float MaxTime = 2;
    public float damage = 10;
    public float ResetTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.transform.position;
        Vector3 myPos = transform.position;
        switch (State)
        {
            case EnemyState.None:
                State = EnemyState.Idle;
                break;

            case EnemyState.Idle:
                {
                    if (Vector3.Distance(targetPos, myPos) < radiusMovement)
                        State = EnemyState.Chase;
                }
                break;

            case EnemyState.Chase:
                {
                    Vector3 direction = (targetPos - myPos).normalized;
                    transform.position += direction * Speed * Time.deltaTime;


                    if (Vector3.Distance(targetPos, myPos) > radiusMovement)
                        State = EnemyState.Idle;

                    if (Vector3.Distance(targetPos, myPos) < radiusattack)
                        State = EnemyState.Attack;
                }
                break;
            case EnemyState.Attack:
                {
                    if (IsAbleToAttack)
                    {

                        Debug.Log("ven maldito");
                        target.GetComponent<Player>().Health -= damage;
                        IsAbleToAttack = false;
                    }
                    ResetTime += Time.deltaTime;
                    if (ResetTime >= MaxTime)
                    {
                        IsAbleToAttack = true;

                        ResetTime = 0;
                    }


                    if (Vector3.Distance(targetPos, myPos) > radiusattack)
                        State = EnemyState.Chase;
                }
                break;

            default:
                break;
        }

    }
}
