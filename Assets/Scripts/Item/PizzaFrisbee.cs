using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PizzaFrisbee : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float duration = 3f;

    [Header("Damage")]
    [SerializeField] private int damage = 2;

    private Camera cam;
    private Vector2 dir;
    private float timer = 0f;

    private void Awake()
    {
        cam = Camera.main;

        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    private void OnEnable()
    {
        dir = Random.insideUnitCircle.normalized;
        if (dir == Vector2.zero) dir = Vector2.right;
        timer = 0f;
    }

    private void Update()
    {
        float dt = Time.deltaTime;
        transform.position += (Vector3)(dir * speed * dt);

        // Bounce when hitting viewport edges
        var vp = cam.WorldToViewportPoint(transform.position);
        if ((vp.x <= 0f && dir.x < 0f) || (vp.x >= 1f && dir.x > 0f)) dir.x = -dir.x;
        if ((vp.y <= 0f && dir.y < 0f) || (vp.y >= 1f && dir.y > 0f)) dir.y = -dir.y;

        timer += dt;
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponentInParent<EnemyBehavior>() ?? other.GetComponent<EnemyBehavior>();
        if (enemy == null || !enemy.isActiveAndEnabled) return;
        enemy.TakeDamage(damage);
        // Pierces by default; no destroy-on-hit
    }
}