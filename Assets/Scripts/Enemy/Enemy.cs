using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Die()
    {
        gameObject.SetActive(false);
        Debug.Log("die enemy");
    }
}