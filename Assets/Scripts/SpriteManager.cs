using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Sprite", menuName = "~/Malediction/Assets/Scripts/SpriteManager.cs/SpriteManager", order = 0)]
public class SpriteManager : ScriptableObject 
{
    public const string EMOTION_NEUTRAL = "neutral";
    public const string EMOTION_HAPPY = "happy";
    public const string EMOTION_SAD = "sad";
    public const string EMOTION_ANGRY = "angry";

    public string characterName;
    public Sprite portraitNeutral, portraitHappy, portraitSad, portraitAngry;

    public Sprite GetPortraitExpression(string emotion)
    {
        switch (emotion)
        {
            default:
                case EMOTION_NEUTRAL: return portraitNeutral;
                case EMOTION_HAPPY: return portraitHappy;
                case EMOTION_SAD: return portraitSad;
                case EMOTION_ANGRY: return portraitAngry;
        }
    }

    
}