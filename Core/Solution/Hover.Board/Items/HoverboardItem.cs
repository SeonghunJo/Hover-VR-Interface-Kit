﻿using System;
using Hover.Common.Items;
using Hover.Common.Items.Types;
using UnityEngine;

namespace Hover.Board.Items {
	
	/*================================================================================================*/
	public class HoverboardItem : MonoBehaviour, IHovercommonItem {

		public enum HoverboardItemType {
			Selector = SelectableItemType.Selector,
			Sticky = SelectableItemType.Sticky,
			Checkbox = SelectableItemType.Checkbox,
			Radio = SelectableItemType.Radio
		}

		public HoverboardItemType Type;
		public string Id = "";
		public string Label = "";
		public float Width = 1;
		public float Height = 1;
		public bool IsVisible = true;
		public bool IsEnabled = true;

		public bool CheckboxValue;

		public bool RadioValue;

		private BaseItem vItem;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IBaseItem GetItem() {
			if ( vItem == null ) {
				BuildItem();
			}

			return vItem;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void BuildItem() {
			switch ( Type ) {
				case HoverboardItemType.Selector:
					vItem = new SelectorItem();
					break;

				case HoverboardItemType.Sticky:
					vItem = new StickyItem();
					break;

				case HoverboardItemType.Checkbox:
					var checkItem = new CheckboxItem();
					checkItem.Value = CheckboxValue;
					vItem = checkItem;
					break;

				case HoverboardItemType.Radio:
					var radItem = new RadioItem();
					radItem.Value = RadioValue;
					vItem = radItem;
					break;

				default:
					throw new Exception("Unhandled item type: "+Type);
			}

			if ( !string.IsNullOrEmpty(Id) ) {
				vItem.Id = Id;
			}

			vItem.DisplayContainer = gameObject;
			vItem.Label = (string.IsNullOrEmpty(Label) ? gameObject.name : Label);
			vItem.Width = Width;
			vItem.Height = Height;
			vItem.IsVisible = IsVisible;
			vItem.IsEnabled = IsEnabled;
		}

	}

}
