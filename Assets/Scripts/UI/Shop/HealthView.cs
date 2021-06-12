using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
	//[SerializeField] private TMP_Text _label;
	//[SerializeField] private TMP_Text _price;
	//[SerializeField] private Image _icon;
	//[SerializeField] private Button _sellButton;

	//private MedicalKit _medicalKit;

	//public event UnityAction<Weapon, WaeponView> SellButtonClick;

	//private void OnEnable()
	//{
	//	_sellButton.onClick.AddListener(OnButtonClick);
	//	_sellButton.onClick.AddListener(TryLockItem);
	//}

	//private void OnDisable()
	//{
	//	_sellButton.onClick.RemoveListener(OnButtonClick);
	//	_sellButton.onClick.RemoveListener(TryLockItem);
	//}

	//private void TryLockItem()
	//{
	//	if (_medicalKit.IsBuyed)
	//		_sellButton.interactable = false;
	//}

	//public void Render(MedicalKit medicalKit)
	//{
	//	_medicalKit = medicalKit;
	//	_label.text = medicalKit.Label;
	//	_price.text = medicalKit.Price.ToString();
	//	_icon.sprite = medicalKit.Icon;
	//}

	//private void OnButtonClick()
	//{
	//	SellButtonClick?.Invoke(_medicalKit, this);
	//}
}

