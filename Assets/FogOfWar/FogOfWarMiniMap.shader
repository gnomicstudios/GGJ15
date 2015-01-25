Shader "Custom/FogOfWarMiniMap" {
    Properties {
        _Color("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _UVScale("UV Scale", float) = 2.0
    }
    SubShader {
        Tags { "Queue"="Overlay" "RenderType"="Transparent" "LightMode"="ForwardBase" }
        Blend SrcAlpha OneMinusSrcAlpha
        Lighting Off
        LOD 200
        
        CGPROGRAM
        #pragma surface surf NoLighting noambient
        
        fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, float aten)
        {
            fixed4 color;
            color.rgb = s.Albedo;
            color.a = s.Alpha;
            return color;
        }

        fixed4 _Color;
        sampler2D _MainTex;
        float _UVScale;

        struct Input {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o) {
            float2 uv = float2(0.5f, 0.5f) + _UVScale * (IN.uv_MainTex - float2(0.5f, 0.5f));
            half4 baseColor = tex2D (_MainTex, uv);
            o.Albedo = baseColor; //_Color.rgb; // * (1.0f - baseColor.b);
            o.Alpha = 1.0f; //green - color of aperture mask
        }
        ENDCG
    } 
    Fallback "Diffuse"
}
