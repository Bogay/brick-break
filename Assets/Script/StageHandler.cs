using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHandler : MonoBehaviour
{
	public static StageHandler instance
	{
		get
		{
			if(!_instance)
			{
				_instance = FindObjectOfType<StageHandler>();
				if(!_instance)
				{
					GameObject soundPlayerObject = new GameObject("StageHandler");
					_instance = soundPlayerObject.AddComponent<StageHandler>();
				}
			}
			return _instance;
		}
	}
	private static StageHandler _instance;

	private int levels;
	private int currentLevel;
	private int blockAmount;
	private StageGenerator stageGenerator;

	void Start()
	{
		if(instance != this)
		{
			Destroy(this);
			return;
		}

		stageGenerator = GetComponent<StageGenerator>();
		levels = stageGenerator.datas.Length;
		currentLevel = -1;
		blockAmount = 0;

		onStageStart();
	}

	void Update()
	{
		if(blockAmount == 0)
		{
			onStageStart();
		}
	}

	private void onStageStart()
	{
		currentLevel++;
		if(!stageGenerator.generate(currentLevel))
		{
			Debug.Log("Congratulations!"); // game end
			return;
		}
		blockAmount = stageGenerator.datas[currentLevel].positions.Length;
		Debug.Log(System.String.Format("Start Stage [{0}], [{1}] blocks to be break.", currentLevel, blockAmount));
	}

	private void onStageEnd()
	{
	}

	public void onBlockBreak()
	{
		blockAmount--;
	}
}