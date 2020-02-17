using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public void Push()
    {
        gameObject.SetActive(false);
    }
}
