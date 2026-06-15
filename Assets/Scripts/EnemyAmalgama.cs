using UnityEngine;

public class EnemyAmalgama : MonoBehaviour
{
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
        FollowTarget();
        if (!IsAbleToAttack)
            TimeToDoSet();
    }
    public void FollowTarget()
    {
        if (target == null)
        {
            return;
        }
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
                }

            }
            else
            {
                transform.position += direction * Speed * Time.deltaTime;
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
}
