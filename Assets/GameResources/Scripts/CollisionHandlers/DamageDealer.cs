using UnityEngine;

[CreateAssetMenu(fileName = "NewDamageDealer", menuName = "Handlers/DamageDealer")]
public class DamageDealer : CollisionHandler
{
    [SerializeField] private int damageAmount;
    public override void ExecuteOnCollision(Collider col, GameObject self)
    {
        var hit = col.gameObject.GetComponent<IDamageable>();
        if (hit != null)
        {
            hit.TakeDamage(damageAmount);
        }
    }
}
