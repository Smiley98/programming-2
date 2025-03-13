using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    GameObject shrapnelPrefab;

    void OnDestroy()
    {
        int shrapnelCount = 6;
        float angle = 360.0f / shrapnelCount;
        for (int i = 0; i < shrapnelCount; i++)
        {
            Vector3 direction = Quaternion.Euler(0.0f, 0.0f, angle * i) * Vector3.right;

            GameObject shrapnel = Instantiate(shrapnelPrefab);
            shrapnel.transform.position = transform.position + direction * 0.75f;
            shrapnel.GetComponent<Rigidbody2D>().linearVelocity = direction * 5.0f;
            shrapnel.GetComponent<SpriteRenderer>().color = Color.magenta;
            Destroy(shrapnel, 0.5f);
        }
    }
}
