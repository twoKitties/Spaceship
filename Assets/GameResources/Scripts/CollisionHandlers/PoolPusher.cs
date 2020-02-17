using UnityEngine;

[CreateAssetMenu(fileName = "NewPoolPusher", menuName = "Handlers/PoolPusher")]
public class PoolPusher : CollisionHandler
{
    public override void ExecuteOnCollision(Collider col, GameObject self)
    {
        var target = self.GetComponent<PooledObject>();
        if (target != null)
            target.Push();
    }
}
