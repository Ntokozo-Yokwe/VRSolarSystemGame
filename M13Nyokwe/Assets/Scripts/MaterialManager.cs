using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    [Tooltip("List of material applied to the skybox")]
    public List<Material> materials;

    /// <summary>
    /// Index of the material currently applied to the skybox
    /// </summary>
    private int index;

    [Tooltip("Apply the first material to the skybox automatically")]
    public bool applyMaterialOnAwake;

    public void Awake()
    {
        if (applyMaterialOnAwake)
        {
            ChangeSkyboxMaterial(0);
        }
    }

    public void ChangeSkyboxMaterial(int i)
    {
        RenderSettings.skybox = materials[i];
        index = i;
    }

    public void NextMaterial()
    {
        int i = index + 1;

        if (i >= materials.Count)
        {
            i = 0;
        }

        ChangeSkyboxMaterial(i);
    }

    public void PreviousMaterial()
    {
        int i = index - 1;

        if (i < 0)
        {
            i = materials.Count - 1;
        }

        ChangeSkyboxMaterial(i);
    }

}
