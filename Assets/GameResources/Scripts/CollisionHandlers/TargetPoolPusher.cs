using UnityEngine;

[CreateAssetMenu(fileName = "NewTargetPoolPusher", menuName = "Handlers/TargetPoolPusher")]
public class TargetPoolPusher : CollisionHandler
{
    public override void ExecuteOnCollision(Collider col, GameObject self)
    {
        var target = col.GetComponent<PooledObject>();
        if (target != null)
            target.Push();
    }
}
