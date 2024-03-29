﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace FrontWpf.MyExtensions
{
	public class ScrollViewerExtensions
	{
		public static readonly DependencyProperty AlwaysScrollToEndProperty = DependencyProperty.RegisterAttached("AlwaysScrollToEnd", typeof(bool), typeof(ScrollViewerExtensions), new PropertyMetadata(false, AlwaysScrollToEndChanged));
		private static bool _autoScroll;

		private static void AlwaysScrollToEndChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (sender is ScrollViewer scroll)
			{
				bool alwaysScrollToEnd = (e.NewValue != null) && (bool)e.NewValue;
				if (alwaysScrollToEnd)
				{
					scroll.ScrollToEnd();
					scroll.ScrollChanged += ScrollChanged;
				}
				else
					scroll.ScrollChanged -= ScrollChanged;
			}
			else
				throw new InvalidOperationException("The attached AlwaysScrollToEnd property can only be applied to ScrollViewer instances.");
		}

		public static bool GetAlwaysScrollToEnd(ScrollViewer scroll)
		{
			if (scroll == null)
				throw new ArgumentNullException("scroll");
			return (bool)scroll.GetValue(AlwaysScrollToEndProperty);
		}

		public static void SetAlwaysScrollToEnd(ScrollViewer scroll, bool alwaysScrollToEnd)
		{
			if (scroll == null)
				throw new ArgumentNullException("scroll");
			scroll.SetValue(AlwaysScrollToEndProperty, alwaysScrollToEnd);
		}

		private static void ScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			if (sender is ScrollViewer scroll)
			{
				if (e.ExtentHeightChange == 0)// User scroll event : set or unset autoscroll mode
					_autoScroll = scroll.VerticalOffset == scroll.ScrollableHeight;
				else if (_autoScroll)// Content scroll event : autoscroll eventually
					scroll.ScrollToVerticalOffset(scroll.ExtentHeight);
			}
			else
				throw new InvalidOperationException("The attached AlwaysScrollToEnd property can only be applied to ScrollViewer instances.");
		}
	}
}
