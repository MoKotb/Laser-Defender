using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.02f;
    private Material material;
    private Vector2 offset;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(0f, backgroundScrollSpeed);
    }

    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
