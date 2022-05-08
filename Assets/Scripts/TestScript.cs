using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
	public QuestionList[] questions;
}
	[System.Serializable]
public class QuestionList
{
	public  string question;
	public string[] answers = new string[3];
}