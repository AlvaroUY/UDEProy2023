﻿using UnityEngine;
using System.Collections;
using VolumetricLines;


public class CreateSinShapedLineStrip : MonoBehaviour 
{
	public int m_numVertices = 50;
	public Material m_volumetricLineStripMaterial;
	public Color m_color;
	public float m_start = 0f;
	public float m_end = Mathf.PI;

	void Start () 
	{
		GameObject go = new GameObject();
		go.transform.parent = transform;

		go.AddComponent<MeshFilter>();

		go.AddComponent<MeshRenderer>();

		var volLineStrip = go.AddComponent<VolumetricLineStripBehavior>();
		volLineStrip.DoNotOverwriteTemplateMaterialProperties = false;
		volLineStrip.TemplateMaterial = m_volumetricLineStripMaterial;
		volLineStrip.LineColor = m_color;
		volLineStrip.LineWidth = 55.0f;
		volLineStrip.LightSaberFactor = 0.83f;

		var lineVertices = new Vector3[m_numVertices];
		for (int i=0; i < m_numVertices; ++i)
		{
			float x = Mathf.Lerp(m_start, m_end, (float)i / (float)(m_numVertices-1));
			float y = Mathf.Sin(x);
			lineVertices[i] = gameObject.transform.TransformPoint(new Vector3(x, y, 0f));
		}

		volLineStrip.UpdateLineVertices(lineVertices);

	}

	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		for (int i=0; i < m_numVertices; ++i)
		{
			float x = Mathf.Lerp(m_start, m_end, (float)i / (float)(m_numVertices-1));
			float y = Mathf.Sin(x);
			Gizmos.DrawSphere(gameObject.transform.TransformPoint(new Vector3(x, y, 0f)), 5f);
		}
	}
	
}
