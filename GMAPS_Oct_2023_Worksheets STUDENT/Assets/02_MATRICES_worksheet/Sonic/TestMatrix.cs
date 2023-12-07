//// Uncomment this whole file.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    private HMatrix2D mat1 = new HMatrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);
    private HMatrix2D mat2 = new HMatrix2D(10, 11, 12, 13, 14, 15, 16, 17, 18);
    private HMatrix2D resultMat = new HMatrix2D();
    private HVector2D vec1 = new HVector2D(19, 20);
    private HVector2D resultVec = new HVector2D();

    void Start()
    {
        mat.SetIdentity();
        mat.Print();
        Question2();
    }

    public void Question2()
    {
        HMatrix2D resultMat = mat1 * mat2;
        HVector2D resultVec = mat1 * vec1;
        resultMat.Print();
        Debug.Log(resultVec.x + ", " + resultVec.y);    //This doesn't work I'm not sure why :/
    }
}
