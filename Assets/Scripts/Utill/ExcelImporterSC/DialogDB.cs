using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

[ExcelAsset]
public class DialogDB : ScriptableObject
{
	public List<DialogDBEntity> Stage1; // Replace 'EntityType' to an actual type that is serializable.
	public List<DialogDBEntity> Stage2; // Replace 'EntityType' to an actual type that is serializable.

	public object PrintField(string name)
    {
        var result = this.GetType().GetField(name).GetValue(this); // public������ �ƴϸ� GetField���� null�� ���ϵȴ�

        return result;
    }
}
