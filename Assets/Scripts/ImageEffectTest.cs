using UnityEngine;

public class ImageEffectTest : MonoBehaviour
{
    [SerializeField]
    Material shader;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, shader);
    }
}
