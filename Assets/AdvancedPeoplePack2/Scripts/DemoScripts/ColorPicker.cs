﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    Image mainImage;

    public RectTransform pickerIcon;

    public Image colorPreview;

    bool _activeCursor;

    public Vector2 offset;

    public UIControllerDEMO UIControllerDEMO;
    public CharacterCustimization CharacterCustimizationInstance;

    public Canvas Canvas;
    private void Awake()
    {
        mainImage = GetComponent<Image>();
    }

    public void CursorEnter()
    {
        if (!pickerIcon.gameObject.activeSelf)
        {
            pickerIcon.gameObject.SetActive(true);
            _activeCursor = true;
        }    
    }

    private void Update()
    {
        if (_activeCursor) 
        {
            CursorMove();
        }
    }
    Color _findColor;
    public Vector2 realSize;
    public void CursorMove()
    {
        pickerIcon.position = Input.mousePosition;

        realSize = mainImage.rectTransform.rect.size * Canvas.scaleFactor;


        offset = (mainImage.rectTransform.position - Input.mousePosition);

        offset = new Vector2((256 / realSize.x) * offset.x, (256 / realSize.y) * offset.y);

        _findColor = mainImage.sprite.texture.GetPixel( (int)-offset.x, 256 -(int)offset.y);

        if(_findColor.a == 1)
        {
            colorPreview.color = _findColor;
            if (CharacterCustimizationInstance)
            {
                if(CharacterCustimizationInstance.BodyPartColor=="skin")
                {
                    CursorPickSkin();
                }
                else if (CharacterCustimizationInstance.BodyPartColor == "Eye")
                {
                    CursorPickEye();
                }
                else if (CharacterCustimizationInstance.BodyPartColor == "hair")
                {
                    CursorPickHair();
                }
                else if (CharacterCustimizationInstance.BodyPartColor == "underwear")
                {
                    CursorPickUnderpants();
                }
            }
        }  
    }

    public void CursorPickSkin()
    {
        if(_findColor.a == 1)
        {
            if(UIControllerDEMO)
            {
                UIControllerDEMO.SetNewSkinColor(_findColor);
            }

            if(CharacterCustimizationInstance)
            {
                CharacterCustimizationInstance.ApplySelectedSkinColor(_findColor);
            }
        }
    }
    public void CursorPickEye()
    {
        if (_findColor.a == 1)
        {
            if (UIControllerDEMO)
            {
                UIControllerDEMO.SetNewEyeColor(_findColor);
            }

            if (CharacterCustimizationInstance)
            {
                CharacterCustimizationInstance.ApplySelectedEyeColor(_findColor);
            }
        }
    }
    public void CursorPickHair()
    {
        if (_findColor.a == 1)
        {
            if (UIControllerDEMO)
            {
                UIControllerDEMO.SetNewHairColor(_findColor);
            }

            if (CharacterCustimizationInstance)
            {
                CharacterCustimizationInstance.ApplySelectedHairColor(_findColor);
            }
        }
            
    }
    public void CursorPickUnderpants()
    {
        if (_findColor.a == 1)
        {
            if (UIControllerDEMO)
            {
                UIControllerDEMO.SetNewUnderpantsColor(_findColor);
            }

            if (CharacterCustimizationInstance)
            {
                CharacterCustimizationInstance.ApplySelectedUnderwearColor(_findColor);
            }
        }
            
    }
    public void CursorExit()
    {
        if (pickerIcon.gameObject.activeSelf)
        {
            pickerIcon.gameObject.SetActive(false);
            _activeCursor = false;
        }
    }
}