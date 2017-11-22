// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Forceling/Standard"
{
	Properties
	{
		_Albedo("Albedo", 2D) = "white" {}
		_AlbedoTint("Albedo Tint", Color) = (1,1,1,0)
		_Metalness("Metalness", 2D) = "white" {}
		_MetalnessIntensity("Metalness Intensity", Range( 0 , 1)) = 0
		_Smoothness("Smoothness", 2D) = "white" {}
		_Roughness("Roughness", 2D) = "white" {}
		[Toggle]_UseRoughness("Use Roughness", Float) = 0
		_SRIntensity("S/R Intensity", Range( 0 , 1)) = 0
		_Normal("Normal", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Off
		CGPROGRAM
		#pragma target 5.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Normal;
		uniform float4 _Normal_ST;
		uniform sampler2D _Albedo;
		uniform float4 _Albedo_ST;
		uniform float4 _AlbedoTint;
		uniform sampler2D _Metalness;
		uniform float4 _Metalness_ST;
		uniform float _MetalnessIntensity;
		uniform float _UseRoughness;
		uniform sampler2D _Smoothness;
		uniform float4 _Smoothness_ST;
		uniform sampler2D _Roughness;
		uniform float4 _Roughness_ST;
		uniform float _SRIntensity;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Normal = i.uv_texcoord * _Normal_ST.xy + _Normal_ST.zw;
			o.Normal = UnpackNormal( tex2D( _Normal, uv_Normal ) );
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			o.Albedo = ( tex2D( _Albedo, uv_Albedo ) * _AlbedoTint ).rgb;
			float2 uv_Metalness = i.uv_texcoord * _Metalness_ST.xy + _Metalness_ST.zw;
			o.Metallic = ( tex2D( _Metalness, uv_Metalness ) * _MetalnessIntensity ).r;
			float2 uv_Smoothness = i.uv_texcoord * _Smoothness_ST.xy + _Smoothness_ST.zw;
			float2 uv_Roughness = i.uv_texcoord * _Roughness_ST.xy + _Roughness_ST.zw;
			o.Smoothness = ( lerp(tex2D( _Smoothness, uv_Smoothness ),( 1.0 - tex2D( _Roughness, uv_Roughness ) ),_UseRoughness) * _SRIntensity ).r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=13801
0;540;1441;478;1520.705;72.56287;2.006892;True;True
Node;AmplifyShaderEditor.SamplerNode;3;-1295.674,112.2055;Float;True;Property;_Roughness;Roughness;5;0;Assets/Graphics/Boats/Materials/TexturesCom_CorrugatedPlates2_1024_roughness.tif;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SamplerNode;2;-940.1797,-82.14554;Float;True;Property;_Smoothness;Smoothness;4;0;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.OneMinusNode;15;-815.1448,119.7103;Float;False;1;0;COLOR;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.RangedFloatNode;13;-550.4971,219.2002;Float;False;Property;_SRIntensity;S/R Intensity;7;0;0;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.SamplerNode;4;-762.1154,355.0304;Float;True;Property;_Metalness;Metalness;2;0;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SamplerNode;1;-722.1872,-505.7061;Float;True;Property;_Albedo;Albedo;0;0;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ColorNode;9;-655.4128,-296.2375;Float;False;Property;_AlbedoTint;Albedo Tint;1;0;1,1,1,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ToggleSwitchNode;11;-553.6927,62.48156;Float;False;Property;_UseRoughness;Use Roughness;6;0;0;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.RangedFloatNode;16;-468.6267,542.5975;Float;False;Property;_MetalnessIntensity;Metalness Intensity;3;0;0;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-280.2017,77.29498;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;20;-234.5751,1113.282;Float;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0.0,0,0,0;False;2;FLOAT;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;17;-198.3313,400.6924;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-299.1941,-401.7239;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;18;-85.46631,757.5246;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.RangedFloatNode;19;-355.7617,899.4297;Float;False;Property;_OcclusionIntensity;Occlusion Intensity;9;0;0;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;21;-483.6042,1423.424;Float;False;Property;_EmissiveIntensity;Emissive Intensity;13;0;0;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.ColorNode;8;-734.6061,1308.914;Float;False;Property;_EmissiveTint;Emissive Tint;12;0;0,0,0,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SamplerNode;6;-743.4061,860.9545;Float;True;Property;_Occlusion;Occlusion;10;0;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SamplerNode;7;-752.013,1095.076;Float;True;Property;_Emissive;Emissive;11;0;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SamplerNode;5;12.08338,421.9868;Float;True;Property;_Normal;Normal;8;0;None;True;0;False;white;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT3;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;514.324,2.403384;Float;False;True;7;Float;ASEMaterialInspector;0;0;Standard;Forceling/Standard;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;0;False;0;0;Opaque;0.5;True;True;0;False;Opaque;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;0;0;0;0;False;2;15;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;OFF;OFF;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;FLOAT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;15;0;3;0
WireConnection;11;0;2;0
WireConnection;11;1;15;0
WireConnection;12;0;11;0
WireConnection;12;1;13;0
WireConnection;20;0;7;0
WireConnection;20;1;8;0
WireConnection;20;2;21;0
WireConnection;17;0;4;0
WireConnection;17;1;16;0
WireConnection;10;0;1;0
WireConnection;10;1;9;0
WireConnection;18;0;6;0
WireConnection;18;1;19;0
WireConnection;0;0;10;0
WireConnection;0;1;5;0
WireConnection;0;3;17;0
WireConnection;0;4;12;0
ASEEND*/
//CHKSM=139DF45BC550F2497330901D27AF9D862581AC6B