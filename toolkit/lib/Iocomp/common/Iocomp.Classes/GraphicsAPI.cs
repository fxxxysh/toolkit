using Iocomp.Types;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public class GraphicsAPI
	{
		private Graphics m_GraphicsMS;

		private Hashtable m_CacheBrushes;

		private Hashtable m_CachePens;

		private StringBuilder m_StringBuilder;

		public Graphics GraphicsMS => this.m_GraphicsMS;

		public Region Clip
		{
			get
			{
				return this.m_GraphicsMS.Clip;
			}
			set
			{
				this.m_GraphicsMS.Clip = value;
			}
		}

		public Rectangle ClipBounds => Rectangle.Truncate(this.m_GraphicsMS.ClipBounds);

		public SmoothingMode SmoothingMode
		{
			get
			{
				return this.m_GraphicsMS.SmoothingMode;
			}
			set
			{
				this.m_GraphicsMS.SmoothingMode = value;
			}
		}

		public TextRenderingHint TextRenderingHint
		{
			get
			{
				return this.m_GraphicsMS.TextRenderingHint;
			}
			set
			{
				this.m_GraphicsMS.TextRenderingHint = value;
			}
		}

		public GraphicsAPI(Graphics graphics)
		{
			this.m_GraphicsMS = graphics;
			this.m_StringBuilder = new StringBuilder();
			this.m_CacheBrushes = new Hashtable(13);
			this.m_CachePens = new Hashtable(13);
		}

		public void CleanUp()
		{
			foreach (Brush value in this.m_CacheBrushes.Values)
			{
				value.Dispose();
			}
			foreach (Pen value2 in this.m_CachePens.Values)
			{
				value2.Dispose();
			}
		}

		public Pen Pen(Color color)
		{
			string key = color.GetHashCode().ToString();
			Pen pen = this.m_CachePens[key] as Pen;
			if (pen == null)
			{
				pen = new Pen(color);
				this.m_CachePens.Add(key, pen);
			}
			return pen;
		}

		public Pen Pen(Color color, DashStyle dashStyle)
		{
			this.m_StringBuilder.Length = 0;
			this.m_StringBuilder.Append(color.GetHashCode().ToString());
			this.m_StringBuilder.Append(dashStyle.ToString());
			string key = this.m_StringBuilder.ToString();
			Pen pen = this.m_CachePens[key] as Pen;
			if (pen == null)
			{
				pen = new Pen(color);
				pen.DashStyle = dashStyle;
				this.m_CachePens.Add(key, pen);
			}
			return pen;
		}

		public Pen Pen(Color color, DashStyle dashStyle, float width)
		{
			this.m_StringBuilder.Length = 0;
			this.m_StringBuilder.Append(color.GetHashCode().ToString());
			this.m_StringBuilder.Append(dashStyle.ToString());
			this.m_StringBuilder.Append("W");
			this.m_StringBuilder.Append(width.ToString());
			string key = this.m_StringBuilder.ToString();
			Pen pen = this.m_CachePens[key] as Pen;
			if (pen == null)
			{
				pen = new Pen(color, width);
				pen.DashStyle = dashStyle;
				this.m_CachePens.Add(key, pen);
			}
			return pen;
		}

		public Pen Pen(Color color, float width)
		{
			this.m_StringBuilder.Length = 0;
			this.m_StringBuilder.Append(color.GetHashCode().ToString());
			this.m_StringBuilder.Append("W");
			this.m_StringBuilder.Append(width.ToString());
			string key = this.m_StringBuilder.ToString();
			Pen pen = this.m_CachePens[key] as Pen;
			if (pen == null)
			{
				pen = new Pen(color, width);
				this.m_CachePens.Add(key, pen);
			}
			return pen;
		}

		public Pen Pen(Color color, DashStyle dashStyle, float dashLength, float spaceLength)
		{
			this.m_StringBuilder.Length = 0;
			this.m_StringBuilder.Append(color.GetHashCode().ToString());
			this.m_StringBuilder.Append(dashStyle.ToString());
			this.m_StringBuilder.Append("DL");
			this.m_StringBuilder.Append(dashLength.ToString());
			this.m_StringBuilder.Append("SL");
			this.m_StringBuilder.Append(spaceLength.ToString());
			string key = this.m_StringBuilder.ToString();
			Pen pen = this.m_CachePens[key] as Pen;
			if (pen == null)
			{
				float[] dashPattern = new float[2]
				{
					dashLength,
					spaceLength
				};
				pen = new Pen(color);
				pen.DashPattern = dashPattern;
				pen.DashStyle = dashStyle;
				this.m_CachePens.Add(key, pen);
			}
			return pen;
		}

		public Brush Brush(Color color)
		{
			string key = color.GetHashCode().ToString();
			Brush brush = this.m_CacheBrushes[key] as Brush;
			if (brush == null)
			{
				brush = new SolidBrush(color);
				this.m_CacheBrushes.Add(key, brush);
			}
			return brush;
		}

		public Brush Brush(HatchStyle style, Color foreColor, Color backColor)
		{
			this.m_StringBuilder.Length = 0;
			this.m_StringBuilder.Append(style.ToString());
			this.m_StringBuilder.Append(foreColor.GetHashCode().ToString());
			this.m_StringBuilder.Append(backColor.GetHashCode().ToString());
			string key = this.m_StringBuilder.ToString();
			Brush brush = this.m_CacheBrushes[key] as Brush;
			if (brush == null)
			{
				brush = new HatchBrush(style, foreColor, backColor);
				this.m_CacheBrushes.Add(key, brush);
			}
			return brush;
		}

		public void SetClip(Rectangle r)
		{
			this.m_GraphicsMS.SetClip(r);
		}

		public void DrawArc(Pen pen, Rectangle rect, float startAngle, float sweepAngle)
		{
			if (rect.Width > 0 && rect.Height > 0)
			{
				this.m_GraphicsMS.DrawArc(pen, rect, startAngle, sweepAngle);
			}
		}

		public void DrawArc(Pen pen, RectangleF rect, float startAngle, float sweepAngle)
		{
			if (!(rect.Width <= 0f) && !(rect.Height <= 0f))
			{
				this.m_GraphicsMS.DrawArc(pen, rect, startAngle, sweepAngle);
			}
		}

		public void FillArc(Brush brush, float startAngle, float sweepAngle, Point centerPoint, int radius, int width)
		{
			if (radius > 0)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				int num = radius + width;
				Rectangle rect = new Rectangle(centerPoint.X - num, centerPoint.Y - num, num * 2, num * 2);
				graphicsPath.AddArc(rect, startAngle, sweepAngle);
				rect = new Rectangle(centerPoint.X - radius, centerPoint.Y - radius, radius * 2, radius * 2);
				graphicsPath.AddArc(rect, startAngle + sweepAngle, 0f - sweepAngle);
				this.FillPath(brush, graphicsPath);
				graphicsPath.Dispose();
			}
		}

		public void FillEllipse(Brush brush, Rectangle rect)
		{
			this.m_GraphicsMS.FillEllipse(brush, rect);
		}

		public void FillEllipse(Brush brush, int x, int y, int width, int height)
		{
			this.m_GraphicsMS.FillEllipse(brush, x, y, width, height);
		}

		public void DrawEllipse(Pen pen, Rectangle rect)
		{
			this.m_GraphicsMS.DrawEllipse(pen, rect);
		}

		public void DrawEllipse(Pen pen, int x, int y, int width, int height)
		{
			this.m_GraphicsMS.DrawEllipse(pen, x, y, width, height);
		}

		public void DrawBitmapTransparent(Bitmap bitmap, Rectangle r)
		{
			Color pixel = bitmap.GetPixel(0, bitmap.Height - 1);
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorKey(pixel, pixel);
			this.m_GraphicsMS.DrawImage(bitmap, r, 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, imageAttributes);
		}

		public void DrawImageTransparent(Image image, Rectangle r)
		{
			Bitmap bitmap = new Bitmap(image);
			this.DrawBitmapTransparent(bitmap, r);
			bitmap.Dispose();
		}

		public void DrawImage(Image image, Point[] destPoints, Rectangle srcRect, GraphicsUnit srcUnit)
		{
			this.m_GraphicsMS.DrawImage(image, destPoints, srcRect, srcUnit);
		}

		public void DrawImage(Image image, int x, int y)
		{
			this.m_GraphicsMS.DrawImage(image, x, y);
		}

		public void DrawLine(Pen pen, int x1, int y1, int x2, int y2)
		{
			this.m_GraphicsMS.DrawLine(pen, x1, y1, x2, y2);
		}

		public void DrawLine(Pen pen, Point pt1, Point pt2)
		{
			this.m_GraphicsMS.DrawLine(pen, pt1.X, pt1.Y, pt2.X, pt2.Y);
		}

		public void DrawPie(Pen pen, Rectangle rect, float startAngle, float sweepAngle)
		{
			if (rect.Width > 0 && rect.Height > 0)
			{
				this.m_GraphicsMS.DrawPie(pen, rect, startAngle, sweepAngle);
			}
		}

		public void FillPie(Brush brush, Rectangle rect, float startAngle, float sweepAngle)
		{
			if (rect.Width > 0 && rect.Height > 0)
			{
				this.m_GraphicsMS.FillPie(brush, rect, startAngle, sweepAngle);
			}
		}

		public void DrawPolygon(Pen pen, Point[] points)
		{
			this.m_GraphicsMS.DrawPolygon(pen, points);
		}

		public void FillPolygon(Brush brush, Point[] points)
		{
			this.m_GraphicsMS.FillPolygon(brush, points);
		}

		public void DrawRectangle(Pen pen, Rectangle rect)
		{
			this.m_GraphicsMS.DrawRectangle(pen, rect);
		}

		public void DrawRectangle(Pen pen, int x, int y, int width, int height)
		{
			this.m_GraphicsMS.DrawRectangle(pen, x, y, width, height);
		}

		public Size MeasureString(Font font)
		{
			return this.MeasureString("0", font, true);
		}

		public Size MeasureString(string text, Font font)
		{
			return this.MeasureString(text, font, true);
		}

		public Size MeasureString(string text, Font font, bool typographic)
		{
			StringFormat format = (!typographic) ? StringFormat.GenericDefault : StringFormat.GenericTypographic;
			SizeF sizeF = this.m_GraphicsMS.MeasureString(text, font, 0, format);
			return new Size((int)Math.Ceiling((double)sizeF.Width) + 1, (int)Math.Ceiling((double)sizeF.Height) + 1);
		}

		public Size MeasureString(string text, Font font, bool typographic, int width)
		{
			StringFormat format = (!typographic) ? StringFormat.GenericDefault : StringFormat.GenericTypographic;
			SizeF sizeF = this.m_GraphicsMS.MeasureString(text, font, width, format);
			return new Size((int)Math.Ceiling((double)sizeF.Width) + 1, (int)Math.Ceiling((double)sizeF.Height) + 1);
		}

		public void DrawString(string s, Font font, Brush brush, RectangleF layoutRectangle)
		{
			this.m_GraphicsMS.DrawString(s, font, brush, layoutRectangle);
		}

		public void DrawString(string s, Font font, Brush brush, Point point, DrawStringFormat format)
		{
			this.m_GraphicsMS.DrawString(s, font, brush, point, format.StringFormat);
		}

		public void DrawString(string s, Font font, Brush brush, Rectangle r, DrawStringFormat format)
		{
			this.m_GraphicsMS.DrawString(s, font, brush, r, format.StringFormat);
		}

		public void DrawString(string s, Font font, Brush brush, float x, float y)
		{
			this.m_GraphicsMS.DrawString(s, font, brush, x, y);
		}

		public void DrawString(string s, Font font, Brush brush, float x, float y, DrawStringFormat format)
		{
			this.m_GraphicsMS.DrawString(s, font, brush, x, y, format.StringFormat);
		}

		public void DrawLines(Pen pen, Point[] points)
		{
			this.m_GraphicsMS.DrawLines(pen, points);
		}

		public void FillPath(Brush brush, GraphicsPath path)
		{
			if (brush != null)
			{
				this.m_GraphicsMS.FillPath(brush, path);
			}
		}

		public void FillRectangle(Brush brush, Rectangle rect)
		{
			if (brush != null)
			{
				this.m_GraphicsMS.FillRectangle(brush, rect);
			}
		}

		public void FillRectangle(Brush brush, int x, int y, int width, int height)
		{
			if (brush != null)
			{
				this.m_GraphicsMS.FillRectangle(brush, x, y, width, height);
			}
		}

		public void ResetClip()
		{
			this.m_GraphicsMS.ResetClip();
		}

		public void Restore(GraphicsState gstate)
		{
			this.m_GraphicsMS.Restore(gstate);
		}

		public GraphicsState Save()
		{
			return this.m_GraphicsMS.Save();
		}

		public void ResetTransform()
		{
			this.m_GraphicsMS.ResetTransform();
		}

		public void RotateTransform(float angle)
		{
			this.m_GraphicsMS.RotateTransform(angle);
		}

		public void RotateTransform(float angle, MatrixOrder order)
		{
			this.m_GraphicsMS.RotateTransform(angle, order);
		}

		public void TranslateTransform(float dx, float dy)
		{
			this.m_GraphicsMS.TranslateTransform(dx, dy);
		}

		public void TranslateTransform(float dx, float dy, MatrixOrder order)
		{
			this.m_GraphicsMS.TranslateTransform(dx, dy, order);
		}

		public void ScaleTransform(float sx, float sy)
		{
			this.m_GraphicsMS.ScaleTransform(sx, sy);
		}

		public void ScaleTransform(float sx, float sy, MatrixOrder order)
		{
			this.m_GraphicsMS.ScaleTransform(sx, sy, order);
		}

		public void FillSurface3D(Rectangle r, Color startColor, Color stopColor, bool reverse)
		{
			if (r.Width != 0 && r.Height != 0)
			{
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(r, startColor, stopColor, 45f);
				linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
				linearGradientBrush.SetBlendTriangularShape(1f);
				this.m_GraphicsMS.FillRectangle(linearGradientBrush, r);
			}
		}

		public void FillTube3D(Rectangle r, Color color, Orientation orientation, float focus, bool sigma)
		{
			this.FillTube3D(r, iColors.Darken3(color), color, orientation, focus, sigma);
		}

		public void FillTube3D(Rectangle r, Color colorStop, Color colorStart, Orientation orientation, float focus, bool sigma)
		{
			if (r.Width != 0 && r.Height != 0)
			{
				LinearGradientBrush linearGradientBrush = (orientation != Orientation.Vertical) ? new LinearGradientBrush(r, colorStop, colorStart, 90f) : new LinearGradientBrush(r, colorStop, colorStart, 0f);
				linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
				if (sigma)
				{
					linearGradientBrush.SetSigmaBellShape(focus);
				}
				else
				{
					linearGradientBrush.SetBlendTriangularShape(focus);
				}
				this.m_GraphicsMS.FillRectangle(linearGradientBrush, r);
			}
		}

		public void FillTube3D(Rectangle r, GraphicsPath path, Color colorStop, Color colorStart, Orientation orientation, float focus, bool sigma)
		{
			if (r.Width != 0 && r.Height != 0)
			{
				LinearGradientBrush linearGradientBrush = (orientation != Orientation.Vertical) ? new LinearGradientBrush(r, colorStop, colorStart, 90f) : new LinearGradientBrush(r, colorStop, colorStart, 0f);
				linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
				if (sigma)
				{
					linearGradientBrush.SetSigmaBellShape(focus);
				}
				else
				{
					linearGradientBrush.SetBlendTriangularShape(focus);
				}
				this.m_GraphicsMS.FillPath(linearGradientBrush, path);
			}
		}

		public void FillGradientPath(Rectangle r, GraphicsPath path, Color colorStop, Color colorStart, float angle, float focus, bool sigma)
		{
			if (r.Width != 0 && r.Height != 0)
			{
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(r, colorStop, colorStart, angle);
				linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
				if (sigma)
				{
					linearGradientBrush.SetSigmaBellShape(focus);
				}
				else
				{
					linearGradientBrush.SetBlendTriangularShape(focus);
				}
				this.m_GraphicsMS.FillPath(linearGradientBrush, path);
			}
		}

		public void FillCircle(Point centerPoint, float radius, Color color)
		{
			Rectangle rect = new Rectangle((int)((float)centerPoint.X - radius), (int)((float)centerPoint.Y - radius), (int)(2f * radius), (int)(2f * radius));
			SolidBrush solidBrush = new SolidBrush(color);
			this.FillEllipse(solidBrush, rect);
			solidBrush.Dispose();
		}

		public void DrawFocusRectangle(Rectangle r, Color backColor)
		{
			this.SmoothingMode = SmoothingMode.Default;
			Pen pen = new Pen(Color.FromArgb(255, backColor.R ^ 0xFF, backColor.G ^ 0xFF, backColor.B ^ 0xFF));
			pen.DashPattern = new float[2]
			{
				2f,
				2f
			};
			this.DrawRectangle(pen, r);
			pen.Dispose();
		}

		public void DrawScaleRotatedText(string s, Font font, Color foreColor, Rectangle r, TextRotation rotation, DrawStringFormat format)
		{
			PointF pointF;
			switch (rotation)
			{
			case TextRotation.X000:
				this.DrawString(s, font, this.Brush(foreColor), r, format);
				break;
			case TextRotation.X090:
			{
				pointF = new PointF((float)(r.Left + r.Height / 2), (float)((r.Top + r.Bottom) / 2));
				GraphicsState gstate = this.Save();
				this.TranslateTransform(pointF.X, pointF.Y);
				this.RotateTransform(90f);
				this.TranslateTransform(0f - pointF.X, 0f - pointF.Y);
				this.DrawString(s, font, this.Brush(foreColor), r, format);
				this.Restore(gstate);
				break;
			}
			case TextRotation.X180:
			{
				pointF = new PointF((float)((r.Left + r.Right) / 2), (float)((r.Top + r.Bottom) / 2));
				GraphicsState gstate = this.Save();
				this.TranslateTransform(pointF.X, pointF.Y);
				this.RotateTransform(180f);
				this.TranslateTransform(0f - pointF.X, 0f - pointF.Y);
				this.DrawString(s, font, this.Brush(foreColor), r, format);
				this.Restore(gstate);
				break;
			}
			case TextRotation.X270:
			{
				pointF = new PointF((float)((r.Left + r.Right) / 2), (float)(r.Top + r.Width / 2));
				GraphicsState gstate = this.Save();
				this.TranslateTransform(pointF.X, pointF.Y);
				this.RotateTransform(270f);
				this.TranslateTransform(0f - pointF.X, 0f - pointF.Y);
				this.DrawString(s, font, this.Brush(foreColor), r, format);
				this.Restore(gstate);
				break;
			}
			}
		}

		public void DrawRotatedText(string s, Font font, Color foreColor, Rectangle r, TextRotation rotation, DrawStringFormat format)
		{
			if (font != null)
			{
				PointF pointF;
				switch (rotation)
				{
				case TextRotation.X000:
					this.DrawString(s, font, this.Brush(foreColor), r, format);
					break;
				case TextRotation.X090:
				{
					r = new Rectangle(r.Left, r.Top, r.Height, r.Width);
					pointF = new PointF((float)(r.Left + r.Height / 2), (float)((r.Top + r.Bottom) / 2));
					GraphicsState gstate = this.Save();
					this.TranslateTransform(pointF.X, pointF.Y);
					this.RotateTransform(90f);
					this.TranslateTransform(0f - pointF.X, 0f - pointF.Y);
					this.DrawString(s, font, this.Brush(foreColor), r, format);
					this.Restore(gstate);
					break;
				}
				case TextRotation.X180:
				{
					pointF = new PointF((float)((r.Left + r.Right) / 2), (float)((r.Top + r.Bottom) / 2));
					GraphicsState gstate = this.Save();
					this.TranslateTransform(pointF.X, pointF.Y);
					this.RotateTransform(180f);
					this.TranslateTransform(0f - pointF.X, 0f - pointF.Y);
					this.DrawString(s, font, this.Brush(foreColor), r, format);
					this.Restore(gstate);
					break;
				}
				case TextRotation.X270:
				{
					r = new Rectangle(r.Left, r.Top, r.Height, r.Width);
					pointF = new PointF((float)((r.Left + r.Right) / 2), (float)(r.Top + r.Width / 2));
					GraphicsState gstate = this.Save();
					this.TranslateTransform(pointF.X, pointF.Y);
					this.RotateTransform(270f);
					this.TranslateTransform(0f - pointF.X, 0f - pointF.Y);
					this.DrawString(s, font, this.Brush(foreColor), r, format);
					this.Restore(gstate);
					break;
				}
				}
			}
		}

		public void DrawGradientArc(Color color, float startAngle, float stopAngle, Point centerPoint, int radius, int width, AngularColorSectionDrawStyle drawStyle)
		{
			if (drawStyle == AngularColorSectionDrawStyle.Draw3D)
			{
				int num = 1;
				Color color2 = color;
				Color color3 = iColors.ToOffColor(color);
				int num2 = width / 2;
				int num3 = radius + num2;
				float num4 = (float)(color3.R - color2.R) / (float)(num2 + 1);
				float num5 = (float)(color3.G - color2.G) / (float)(num2 + 1);
				float num6 = (float)(color3.B - color2.B) / (float)(num2 + 1);
				Rectangle rect = new Rectangle(centerPoint.X - num3, centerPoint.Y - num3, num3 * 2, num3 * 2);
				for (double num7 = 0.0; num7 < (double)num2; num7 += (double)num)
				{
					Color color4 = Color.FromArgb(color2.R + (int)((double)num4 * num7), color2.G + (int)((double)num5 * num7), color2.B + (int)((double)num6 * num7));
					this.DrawArc(this.Pen(color4), rect, startAngle, stopAngle - startAngle);
					rect.Inflate(-num, -num);
				}
				if (width % 2 == 1)
				{
					num2++;
				}
				num4 = (float)(color3.R - color2.R) / (float)(num2 + 1);
				num5 = (float)(color3.G - color2.G) / (float)(num2 + 1);
				num6 = (float)(color3.B - color2.B) / (float)(num2 + 1);
				rect = new Rectangle(centerPoint.X - num3, centerPoint.Y - num3, num3 * 2, num3 * 2);
				rect.Inflate(num, num);
				for (double num8 = 0.0; num8 < (double)num2; num8 += (double)num)
				{
					Color color4 = Color.FromArgb(color2.R + (int)((double)num4 * num8), color2.G + (int)((double)num5 * num8), color2.B + (int)((double)num6 * num8));
					this.DrawArc(this.Pen(color4), rect, startAngle, stopAngle - startAngle);
					rect.Inflate(num, num);
				}
			}
			else
			{
				this.FillArc(this.Brush(color), startAngle, stopAngle - startAngle, centerPoint, radius, width);
			}
		}

		public void DrawGradientRect(Color colorStart, Color colorStop, Rectangle r, bool vertical, bool center, bool sigma)
		{
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(r, colorStop, colorStart, 90f);
			if (sigma)
			{
				if (center)
				{
					linearGradientBrush.SetSigmaBellShape(0.5f);
				}
				else
				{
					linearGradientBrush.SetSigmaBellShape(0f);
				}
			}
			else if (center)
			{
				linearGradientBrush.SetBlendTriangularShape(0.5f);
			}
			else
			{
				linearGradientBrush.SetBlendTriangularShape(0f);
			}
			this.FillRectangle(linearGradientBrush, r);
			linearGradientBrush.Dispose();
		}

		public void DrawGradientCircle(Color color, Point centerPoint, int radius, bool mouseDown, float rotationAngle, bool reverse)
		{
			iColors.FaceColorFlat = iColors.Darken1(color);
			if (mouseDown)
			{
				iColors.FaceColorFlat = iColors.Lighten2(iColors.FaceColorFlat);
			}
			Rectangle rect = new Rectangle(centerPoint.X - radius, centerPoint.Y - radius, radius * 2, radius * 2);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddEllipse(rect);
			PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
			pathGradientBrush.CenterColor = Color.White;
			pathGradientBrush.SurroundColors = new Color[1]
			{
				iColors.FaceColorFlat
			};
			float num = 225f - rotationAngle;
			pathGradientBrush.CenterPoint = Math2.ToRotatedPoint((double)num, (double)((float)radius * 0.67f), centerPoint);
			this.FillPath(pathGradientBrush, graphicsPath);
			pathGradientBrush.Dispose();
			this.DrawEllipse(this.Pen(iColors.FaceColorFlat), rect);
		}

		public void DrawTankBody(Color color, Rectangle r)
		{
			Color colorStop = iColors.Darken2(color);
			Color colorStart = iColors.Lighten3(color);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(r.Left, r.Top, r.Width, r.Width, 180f, 180f);
			graphicsPath.AddArc(r.Left, r.Bottom - r.Width, r.Width, r.Width, 0f, 180f);
			this.FillTube3D(r, graphicsPath, colorStop, colorStart, Orientation.Vertical, 0.5f, true);
		}
	}
}
