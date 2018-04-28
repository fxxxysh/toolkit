using System;
using System.Drawing;

namespace Iocomp.Classes
{
	public sealed class Math2
	{
		public static double TIME_HOUR => 0.041666666666666664;

		public static double TIME_MINUTE => Math2.TIME_HOUR / 60.0;

		public static double TIME_SECOND => Math2.TIME_MINUTE / 60.0;

		public static double TIME_MILLISECOND => Math2.TIME_SECOND / 1000.0;

		private Math2()
		{
		}

		public static double Fraction(double value)
		{
			return value - (double)(int)value;
		}

		public static double Radians(double degrees)
		{
			return degrees / 360.0 * 2.0 * 3.1415926535897931;
		}

		public static double ToAngle(double radians)
		{
			return radians / 6.2831853071795862 * 360.0;
		}

		public static int Row(int index, int colCount)
		{
			return index / colCount;
		}

		public static int Col(int index, int colCount)
		{
			return index % colCount;
		}

		public static double Cos(double angle)
		{
			return Math.Cos(Math2.Radians(angle));
		}

		public static double Sin(double angle)
		{
			return Math.Sin(Math2.Radians(angle));
		}

		public static int Delta(int value1, int value2)
		{
			return Math.Abs(value1 - value2);
		}

		public static double Clamp(double value, double min, double max)
		{
			if (value < min)
			{
				return min;
			}
			if (value > max)
			{
				return max;
			}
			return value;
		}

		public static void Switch(ref double value1, ref double value2)
		{
			double num = value1;
			value1 = value2;
			value2 = num;
		}

		public static void Switch(ref float value1, ref float value2)
		{
			float num = value1;
			value1 = value2;
			value2 = num;
		}

		public static void Switch(ref int value1, ref int value2)
		{
			int num = value1;
			value1 = value2;
			value2 = num;
		}

		public static void Switch(ref bool value1, ref bool value2)
		{
			bool flag = value1;
			value1 = value2;
			value2 = flag;
		}

		public static Size Max(Size size1, Size size2)
		{
			int width = size1.Width;
			int height = size1.Height;
			width = Math.Max(width, size2.Width);
			height = Math.Max(height, size2.Height);
			return new Size(width, height);
		}

		public static SizeF Max(SizeF size1, SizeF size2)
		{
			float width = size1.Width;
			float height = size1.Height;
			width = Math.Max(width, size2.Width);
			height = Math.Max(height, size2.Height);
			return new SizeF(width, height);
		}

		public static double AngleNormalized(double angle)
		{
			double num = angle % 360.0;
			if (num == 360.0)
			{
				return 0.0;
			}
			if (num >= 0.0)
			{
				return num;
			}
			return 360.0 + num;
		}

		public static double PointToAngle(Point centerPoint, int x, int y)
		{
			return Math2.AngleNormalized(Math2.ToAngle(Math.Atan2((double)(y - centerPoint.Y), (double)(x - centerPoint.X))));
		}

		public static bool InRangeDelta(double value, double min, double max)
		{
			if (value >= min - Math.Abs(min * 1E-14))
			{
				return value <= max + Math.Abs(max * 1E-14);
			}
			return false;
		}

		public static Point ToCenterPoint(Rectangle r)
		{
			return new Point((r.Left + r.Right) / 2, (r.Top + r.Bottom) / 2);
		}

		public static Point ToRotatedPoint(double angle, double radius, Point centerPoint)
		{
			return new Point((int)Math.Round(Math2.Cos(angle) * radius + (double)centerPoint.X, 14), (int)Math.Round(Math2.Sin(angle) * radius + (double)centerPoint.Y, 14));
		}

		public static Point ToRotatedPoint(double angle, double radius, double centerX, double centerY)
		{
			return new Point((int)Math.Round(Math2.Cos(angle) * radius + centerX), (int)Math.Round(Math2.Sin(angle) * radius + centerY));
		}

		public static Rectangle TextRectangleAngular(Size textSize, Point point, int margin, double angle)
		{
			int num;
			int num2;
			if (angle == 0.0)
			{
				num = margin;
				num2 = -textSize.Height / 2;
			}
			else if (angle == 180.0)
			{
				num = -margin - textSize.Width;
				num2 = -textSize.Height / 2;
			}
			else if (angle == 90.0)
			{
				num = -textSize.Width / 2;
				num2 = margin;
			}
			else if (angle == 270.0)
			{
				num = -textSize.Width / 2;
				num2 = -margin - textSize.Height;
			}
			else if (angle > 90.0 && angle < 270.0)
			{
				num = -margin - textSize.Width;
				num2 = -textSize.Height / 2;
			}
			else
			{
				num = margin;
				num2 = -textSize.Height / 2;
			}
			return new Rectangle(point.X + num, point.Y + num2, textSize.Width + 1, textSize.Height + 1);
		}

		public static double Hypotenuse(double a, double b)
		{
			return Math.Sqrt(a * a + b * b);
		}

		public static Point[] ToRotatedPoints(double angle, Rectangle r)
		{
			Point[] array = new Point[4];
			Point centerPoint = Math2.ToCenterPoint(r);
			Point centerPoint2 = Math2.ToRotatedPoint(angle, (double)(r.Width / 2), centerPoint);
			Point centerPoint3 = Math2.ToRotatedPoint(angle + 180.0, (double)(r.Width / 2), centerPoint);
			array[0] = Math2.ToRotatedPoint(angle + 90.0, (double)(r.Height / 2), centerPoint2);
			array[3] = Math2.ToRotatedPoint(angle - 90.0, (double)(r.Height / 2), centerPoint2);
			array[1] = Math2.ToRotatedPoint(angle + 90.0, (double)(r.Height / 2), centerPoint3);
			array[2] = Math2.ToRotatedPoint(angle - 90.0, (double)(r.Height / 2), centerPoint3);
			return array;
		}

		public static int GetDoubleToMilliseconds(double value)
		{
			DateTime dateTime = Math2.DoubleToDateTime(value);
			int num = (int)value * 24 * 60 * 60 * 1000 + dateTime.Hour * 60 * 60 * 1000 + dateTime.Minute * 60 * 1000 + dateTime.Second * 1000 + dateTime.Millisecond;
			if (num < 0)
			{
				return 2147483647;
			}
			return num;
		}

		public static int GetDoubleToSeconds(double value)
		{
			DateTime dateTime = Math2.DoubleToDateTime(value);
			int num = (int)value * 24 * 60 * 60 + dateTime.Hour * 60 * 60 + dateTime.Minute * 60 + dateTime.Second;
			if (num < 0)
			{
				return 2147483647;
			}
			return num;
		}

		public static int GetDoubleToMinutes(double value)
		{
			DateTime dateTime = Math2.DoubleToDateTime(value);
			int num = (int)value * 24 * 60 + dateTime.Hour * 60 + dateTime.Minute;
			if (num < 0)
			{
				return 2147483647;
			}
			return num;
		}

		public static int GetDoubleToHours(double value)
		{
			int num = (int)value * 24 + Math2.DoubleToDateTime(value).Hour;
			if (num < 0)
			{
				return 2147483647;
			}
			return num;
		}

		public static double DateTimeToDouble(DateTime value)
		{
			long num = value.Ticks;
			if (num == 0L)
			{
				return 0.0;
			}
			if (num < 864000000000L)
			{
				num += 599264352000000000L;
			}
			if (num < 31241376000000000L)
			{
				throw new OverflowException("Invalid OA Date");
			}
			long num2 = (num - 599264352000000000L) / 10000L;
			if (num2 < 0L)
			{
				long num3 = num2 % 86400000L;
				if (num3 != 0L)
				{
					num2 -= (86400000L + num3) * 2L;
				}
			}
			return (double)num2 / 86400000.0;
		}

		public static DateTime DoubleToDateTime(double value)
		{
			if (!(value >= 2958466.0) && value > -657435.0)
			{
				long num = (long)(value * 86400000.0 + ((value >= 0.0) ? 0.5 : -0.5));
				if (num < 0L)
				{
					num -= num % 86400000L * 2L;
				}
				num += 59926435200000L;
				if (num >= 0L && num < 315537897600000L)
				{
					return new DateTime(num * 10000L);
				}
				throw new ArgumentException("Invalid OA Date");
			}
			throw new ArgumentException("Invalid OA Date");
		}

		public static double TimeSpanToDouble(TimeSpan value)
		{
			double num = (double)value.Days;
			num += (double)value.Hours / 24.0;
			num += (double)value.Minutes / 1440.0;
			num += (double)value.Seconds / 86400.0;
			return num + (double)value.Milliseconds / 86400000.0;
		}
	}
}
