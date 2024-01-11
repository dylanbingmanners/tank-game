using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerStatController))]
[RequireComponent(typeof(PlayerWeaponController))]
public class PlayerController : MonoBehaviour
{
    public Projectile Bullet;

    private Rigidbody2D _rigidBody;
    private PlayerStatController _stats;
    private PlayerWeaponController _weaponController;
    private float _moveX;
    private float _moveY;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _stats = GetComponent<PlayerStatController>();
        _weaponController = GetComponent<PlayerWeaponController>();
    }

    private void Update()
    {
        _moveX = Input.GetAxisRaw("Horizontal");
        _moveY = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0))
        {
            _weaponController.FirePrimaryDown();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _weaponController.FirePrimaryUp();
        }

        if (Input.GetMouseButton(0))
        {
            _weaponController.FirePrimaryHold();
        }

        if (Input.GetMouseButtonDown(1))
        {
            _weaponController.FireSecondaryDown();
        }

        if (Input.GetMouseButtonUp(1))
        {
            _weaponController.FireSecondaryUp();
        }

        if (Input.GetMouseButton(1))
        {
            _weaponController.FireSecondaryHold();
        }

    }

    private void FixedUpdate()
    {
        Vector2 normalizedAcceleration = new Vector2(_moveX, _moveY).normalized;

        if(normalizedAcceleration.x == 0)
        {
            float xvel = _rigidBody.velocity.x * _stats.GetDeceleration();
            _rigidBody.velocity = new Vector2(xvel, _rigidBody.velocity.y);
        }

        if(normalizedAcceleration.y == 0)
        {
            float yvel = _rigidBody.velocity.y * _stats.GetDeceleration();
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, yvel);
        }

        _rigidBody.velocity += normalizedAcceleration * _stats.GetAcceleration();
        _rigidBody.velocity = Vector2.ClampMagnitude(_rigidBody.velocity, _stats.GetSpeed());

    }
}
