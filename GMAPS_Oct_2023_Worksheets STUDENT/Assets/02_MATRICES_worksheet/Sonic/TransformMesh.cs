//using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    private Vector3[] vertices; //{ get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();
    private HVector2D pos = new HVector2D();
    private MeshManager meshManager;

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);
        //Translate(1, 1);
        Rotate(-45);
    }

    void Translate(float x, float y)
    {
        transformMatrix.SetIdentity();
        transformMatrix.SetTranslationMat(x, y);    //Moves matrix based on x and y
        Transform();

        pos = transformMatrix * pos;    //Updates current position
    }

   void Rotate(float angle)
   {
       toOriginMatrix.SetTranslationMat(-pos.x, -pos.y);    //Moves matrix to origin
       fromOriginMatrix.SetTranslationMat(pos.x, pos.y);    //Moves back to original position from origin
       
       rotateMatrix.SetRotationMat(angle);                  //Rotates the matrix based on the angle

       transformMatrix.SetIdentity();
       transformMatrix = rotateMatrix * fromOriginMatrix * toOriginMatrix;  //Multiplied in reverse order?

       Transform();
   }

   private void Transform()
   {
       vertices = meshManager.clonedMesh.vertices;

       for (int i = 0; i < vertices.Length; i++)
       {
           HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);    //Update x, y values
           vert = transformMatrix * vert;
           vertices[i].x = vert.x;  //Updates new values to vert.x and y
           vertices[i].y = vert.y;
       }
       meshManager.clonedMesh.vertices = vertices;
   }
}