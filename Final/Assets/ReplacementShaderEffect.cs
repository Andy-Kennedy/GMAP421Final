using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacementShaderEffect : MonoBehaviour {

    public Shader ReplacementShader;
    public Color OverDrawColor;

    // Use this for initialization

    void OnValidate()
    {
        Shader.SetGlobalColor("_OverDrawColor", OverDrawColor);
    }
    void OnEnable () {
        if (ReplacementShader != null){
            GetComponent<Camera>().SetReplacementShader(ReplacementShader, "");
        }
	}
	
	// Update is called once per frame
	void OnDisable () {
        GetComponent<Camera>().ResetReplacementShader();
	}
}
