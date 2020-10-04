using UnityEngine;

[ExecuteInEditMode]
public class PostProcessing : MonoBehaviour
{
    [SerializeField]
    private Material _postprocessMaterial;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        var temporaryTexture = RenderTexture.GetTemporary(source.width, source.height);
        Graphics.Blit(source, temporaryTexture, _postprocessMaterial, 0);
        Graphics.Blit(temporaryTexture, destination, _postprocessMaterial, 1);
        RenderTexture.ReleaseTemporary(temporaryTexture);
    }
}