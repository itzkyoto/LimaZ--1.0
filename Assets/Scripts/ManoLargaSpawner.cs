using UnityEngine;

public class ManoLargaSpawner : MonoBehaviour
    {
        public GameObject EnemyPreFab;
        public float SpawnTimer = 3f;
        public float range;



        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            TimerMachine();

        }
        public void TimerMachine()
        {
            SpawnTimer -= Time.deltaTime;
            if (SpawnTimer < 0)
            {
                SpawnEnemy();
                SpawnTimer = 3f;
            }
        }
        public void SpawnEnemy()
        {
            Vector3 randomDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
            Vector3 fullLenghtDir = randomDir * Random.Range(0f, range);
            GameObject enemy = Instantiate(EnemyPreFab, transform.position, Quaternion.identity);
            enemy.transform.position += fullLenghtDir;

        }


    }
