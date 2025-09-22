using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material; // dành cho các đối tượng có Renderer
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f; // dùng để tính toán tốc độ cuộn
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0)); // dùng để cuộn texture
    }
}
