using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    protected Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void  Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        MoveTowardsPlayer();
    }

    protected void MoveTowardsPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            FlipEnemy();
        }
    }

    protected void FlipEnemy()
    {
        if (player != null)
        {
            transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
        }
    }

    public virtual void TakeDamage()
    {
        Die();
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }

}
