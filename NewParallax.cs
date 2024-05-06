using UnityEngine;

public class NewParallax : MonoBehaviour
{
    private Material mat;
    private float distance;

    public float speed = 0.2f;

    void Start() => mat = GetComponent<Renderer>().material;

    void Update()
    {
        distance += Time.deltaTime * speed;
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
