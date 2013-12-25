using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace JiaowuHelper
{
	class Postion
	{
		public static Point getPostion(Form form, float LeftRight, float UpDown, Form parent)
		{
			Point point = new Point();
			int width, height, x, y;
			if (parent != null)
			{
				x = parent.Location.X;
				y = parent.Location.Y;
				width = parent.Width;
				height = parent.Height;
			}
			else
			{
				x = y = 0;
				width = Screen.PrimaryScreen.WorkingArea.Width;
				height = Screen.PrimaryScreen.WorkingArea.Height;
			}
			point.X = x + Math.Abs((int)(LeftRight * (width - form.Width)));
			point.Y = y + Math.Abs((int)(UpDown * (height - form.Height)));
			return point;
		}
		public static Point getPostion(Form form, float LeftRight, float UpDown)
		{
			return getPostion(form, LeftRight, UpDown, null);
		}
		public static Point getRightDown(Form form, int right, int down)
		{
			Point point = new Point();
			int width, height;
			width = Screen.PrimaryScreen.WorkingArea.Width;
			height = Screen.PrimaryScreen.WorkingArea.Height;
			if (right < 0)
				point.X = -right;
			else
				point.X = width - form.Width - right;
			if (down < 0)
				point.Y = -down;
			else
				point.Y = height - form.Height - down;

			return point;
		}
	}
}
