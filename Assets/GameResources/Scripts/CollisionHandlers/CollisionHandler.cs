using UnityEngine;

public abstract class CollisionHandler : ScriptableObject
{
    public abstract void ExecuteOnCollision(Collider col, GameObject self);
}
