using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animationManager : MonoBehaviour
{
    public List<Sprite> frogSprites = new List<Sprite>();
    public Image leftImage;
    public Image middleImage;
    public Image rightImage;
    public Image movingImage;
    public AudioClip arrowButtonPressSound;
    public AudioClip callButtonSound;
    public GameObject onCallButton;
    public GameObject onReturnButton;
    
    private AudioSource audioSource;
    private Animator anim;

    private int calledFrogNum;

    private int leftCurrentPlace;
    private int middleCurrentPlace;
    private int rightCurrentPlace;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        onReturnButton.SetActive(false);
        onCallButton.SetActive(true);
        leftImage.sprite = frogSprites[0];
        leftCurrentPlace = 0;
        middleImage.sprite = frogSprites[1];
        middleCurrentPlace = 1;
        rightImage.sprite = frogSprites[2];
        rightCurrentPlace = 2;
    }

    public void OnCallButton()
    {
        audioSource.PlayOneShot(callButtonSound);
        onReturnButton.SetActive(true);
        onCallButton.SetActive(false);
        calledFrogNum = middleCurrentPlace;
        nintenfrogManager.instance.calledFrogNum = calledFrogNum;
        nintenfrogManager.instance.frogs[calledFrogNum].OnCallFrog();
    }

    public void OnReturnButton()
    {
        onReturnButton.SetActive(false);
        onCallButton.SetActive(true);
        nintenfrogManager.instance.frogs[calledFrogNum].OnReturnFrog();
    }

    public void LeftArrowButton()
    {
        audioSource.PlayOneShot(arrowButtonPressSound);
        BeforeImagesLeft();
    }

    public void RightArrowButton()
    {
        audioSource.PlayOneShot(arrowButtonPressSound);
        BeforeImagesRight();
    }

    public void ResetRightMoveSideToSide()
    {
        if (leftCurrentPlace == 0)
        {
            var tempColor = leftImage.color;
            tempColor.a = 0;
            leftImage.color = tempColor;
            leftCurrentPlace--;
        }
        else
        {
            var tempColor = leftImage.color;
            tempColor.a = 1;
            leftImage.color = tempColor;
            leftCurrentPlace--;
            leftImage.sprite = frogSprites[leftCurrentPlace];
        }

        if (middleCurrentPlace == 0)
        {
            //do nothing
        }
        else
        {
            middleCurrentPlace--;
            middleImage.sprite = frogSprites[middleCurrentPlace];
        }

        if (rightCurrentPlace == 1)
        {
            //do nothing
        }else if (rightCurrentPlace == frogSprites.Count)
        {
            var tempColor = rightImage.color;
            tempColor.a = 1;
            rightImage.color = tempColor;
            rightCurrentPlace--;
            rightImage.sprite = frogSprites[rightCurrentPlace];
        }else
        {
            rightCurrentPlace--;
            rightImage.sprite = frogSprites[rightCurrentPlace];
        }
        var movingColor = movingImage.color;
        movingColor.a = 1;
        movingImage.color = movingColor;
        anim.SetInteger("MoveSideToSide", 0);
    }
    
    public void ResetLeftMoveSideToSide()
    {
        if (rightCurrentPlace == frogSprites.Count - 1)
        {
            var tempColor = rightImage.color;
            tempColor.a = 0;
            rightImage.color = tempColor;
            rightCurrentPlace++;
        }
        else
        {
            var tempColor = rightImage.color;
            tempColor.a = 1;
            rightImage.color = tempColor;
            rightCurrentPlace++;
            rightImage.sprite = frogSprites[rightCurrentPlace];
        }

        if (middleCurrentPlace == frogSprites.Count - 1)
        {
            //do nothing
        }
        else
        {
            middleCurrentPlace++;
            middleImage.sprite = frogSprites[middleCurrentPlace];
        }

        if (leftCurrentPlace == frogSprites.Count - 2)
        {
            //do nothing
        }else if (leftCurrentPlace == -1)
        {
            var tempColor = leftImage.color;
            tempColor.a = 1;
            leftImage.color = tempColor;
            leftCurrentPlace++;
            leftImage.sprite = frogSprites[leftCurrentPlace];
        }
        else
        {
            leftCurrentPlace++;
            leftImage.sprite = frogSprites[leftCurrentPlace];
        }
        var movingColor = movingImage.color;
        movingColor.a = 1;
        movingImage.color = movingColor;
        anim.SetInteger("MoveSideToSide", 0);
    }

    public void BeforeImagesRight()
    {
        if (middleCurrentPlace == 0)
        {
            //do nothing
        }else if (middleCurrentPlace == 1)
        {
            var tempColor = movingImage.color;
            tempColor.a = 0;
            movingImage.color = tempColor;
            anim.SetInteger("MoveSideToSide", 1);
        }
        else
        {
            var movingNum = leftCurrentPlace - 1;
            movingImage.sprite = frogSprites[movingNum];
            anim.SetInteger("MoveSideToSide", 1);
        }
    }

    public void BeforeImagesLeft()
    {
        if (middleCurrentPlace == frogSprites.Count - 1)
        {
            //do nothing
        }else if (middleCurrentPlace == frogSprites.Count - 2)
        {
            var tempColor = movingImage.color;
            tempColor.a = 0;
            movingImage.color = tempColor;
            anim.SetInteger("MoveSideToSide", -1);
        }
        else
        {
            var movingNum = rightCurrentPlace + 1;
            movingImage.sprite = frogSprites[movingNum];
            anim.SetInteger("MoveSideToSide", -1);
        }
    }
}
