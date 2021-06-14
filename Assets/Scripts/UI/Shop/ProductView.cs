using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProductView : MonoBehaviour
{
	[SerializeField] private TMP_Text _label;
	[SerializeField] private TMP_Text _price;
	[SerializeField] private Image _icon;
	[SerializeField] private Button _sellButton;

	private Product _product;

	public event UnityAction<Product, ProductView> SellButtonClick;

	private void OnEnable()
	{
		_sellButton.onClick.AddListener(OnButtonClick);
		_sellButton.onClick.AddListener(TryLockItem);
	}

	private void OnDisable()
	{
		_sellButton.onClick.RemoveListener(OnButtonClick);
		_sellButton.onClick.RemoveListener(TryLockItem);
	}

	private void TryLockItem()
	{
		if (_product.IsBuyed)
			_sellButton.interactable = false;
	}

	public void Render(Product product)
	{
		_product = product;
		_label.text = product.Label;
		_price.text = product.Price.ToString();
		_icon.sprite = product.Icon;
	}

	private void OnButtonClick()
	{
		SellButtonClick?.Invoke(_product, this);
	}
}
