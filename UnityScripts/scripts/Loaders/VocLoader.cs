using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for loading VOC audio files
/// </summary>
public class VocLoader : Loader {

    public AudioClip Audio;
    public int DataSize;
    public int SamplingRate;
    public int Codec;
    public int Hertz;


    public VocLoader(string clipPath, string clipName)
    {
        char[] VocData;
        if (ReadStreamFile(clipPath, out VocData))
        {
            ProcessAudioBytes(VocData, clipName);
        }
        else
        {
            Debug.Log("Unable to load audio clip " + clipPath);
        }
    }


    public VocLoader(char[] VocData, string clipName)
    {
        ProcessAudioBytes(VocData, clipName);
    }

    private void ProcessAudioBytes(char[] VocData, string clipName)
    {
        string Header = "";
        //Check file header
        for (int i = 0; i < 19; i++)
        {
            Header = Header + VocData[i];
        }
        if (Header == "Creative Voice File")
        {
            if (VocData[0x1A] == 1)//Regular sound data
            {
                DataSize = (int)getValAtAddress(VocData, 0x1B, 24);
                SamplingRate = VocData[0x1E];
                Hertz = (-1000000) / (SamplingRate - 256);
                Codec = VocData[0x1F];
                float[] samples = new float[DataSize];
                //Data Begins from here
                for (int i = 0; i < DataSize; i++)
                {
                    if (i + 32 <= VocData.GetUpperBound(0))
                    {
                        samples[i] = (float)(VocData[i + 32] / 255f);
                    }
                }
                Audio = AudioClip.Create(clipName, DataSize, 1, Hertz, false);
                Audio.SetData(samples, 0);
            }
            else
            {
                Debug.Log("No Audio Data Detected " + clipName);
            }
        }
        else
        {
            Debug.Log("Invalid File Header " + clipName);
        }
    }




}
