using UnityEngine;
using System.Collections;

public class Cuts : GuiBase {
	
	//Base class for cutscene scripts.
	//Implement a start funcfion that sets up the arrays in the subclasses
	
	
	//image arrays
	protected float[] ImageTimes=new float[50]; //The time that the frame begins.
	protected string[] ImageFrames=new string[50]; //The cut that plays at that point.
	protected int[] ImageLoops=new int[50];//How many times the image loops until fade to black.
	
	//Subtitle arrays
	protected float[] SubsTimes=new float[50]; //The time that the subtitle appears.
	protected int[] SubsStringIndices=new int[50]; //The string no to display.
	protected float[] SubsDuration=new float[50]; //The duration of the string. Must be less than time to next sub.

	//Speeh arrays
	protected float[] AudioTimes=new float[50];//The time that the audio clip begins at.
	protected string[] AudioClipName=new string[50];//The clip to play at that time.
	
	public int StringBlockNo;    //What block the subtitles are drawn from
	
	protected int noOfImages;
	protected int noOfSubs;
	protected int noOfAudioClips;
	
	public virtual string getFillerAnim()
	{
		return "cs000_n01";
	}
	
	public int NoOfImages()
	{
		return noOfImages;
	}
	
	public float getImageTime(int index)
	{
		return ImageTimes[index];
	}
	
	public int getImageLoops(int index)
	{
		return ImageLoops[index];
	}
	
	public string getImageFrame(int index)
	{
		return ImageFrames[index];
	}
	
	public int getNoOfSubs()
	{
		return  noOfSubs;
	}
	
	public float getSubTime(int index)
	{
		return SubsTimes[index];
	}
	
	public int getSubIndex(int index)
	{
		return SubsStringIndices[index];
	}
	
	public float getSubDuration(int index)
	{
		return SubsDuration[index];
	}
	
	public int getNoOfAudioClips()
	{
		return noOfAudioClips;
	}
	
	public float getAudioTime(int index)
	{
		return AudioTimes[index];
	}
	
	public string getAudioClip(int index)
	{
		return AudioClipName[index];
	}
	
}
