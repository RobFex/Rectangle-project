using System;
using System.Security.Cryptography;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			// так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
			if (r1.Left > r2.Right || r2.Left > r1.Right)
			{
				return false;
			}
			else if (r2.Top > r1.Bottom || r1.Top > r2.Bottom)
			{
				return false;
			}
			else 
			{ 
				return true;
            }
        }

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			if (AreIntersected(r1, r2) == true)
			{
				if (IndexOfInnerRectangle(r1, r2) == 0)
				{ 
					return r1.Height * r1.Width;
                }
				else if (IndexOfInnerRectangle(r1, r2) == 1)
				{
					return r2.Height * r2.Width;
				}
				else
				{
                    int right = Math.Min(r1.Right, r2.Right);
						int left = Math.Max(r1.Left, r2.Left);
						int bottom = Math.Min(r1.Bottom, r2.Bottom);
						int top = Math.Max(r1.Top, r2.Top);
						int sideOne = right - left;
						int sideTwo = top - bottom;
						int result = sideOne * sideTwo;
						if (result % 2 != 1 || result + 1 % 2 != 1)
						{
							return result * -1;
						}
                        return result;
				}
            }
			else
			{
                return 0;
            }
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			if (r2.Top <= r1.Top && r2.Bottom >= r1.Bottom && r2.Right >= r1.Right && r2.Left <= r1.Left)
			{
				return 0;
			}
			else if (r1.Top <= r2.Top && r1.Bottom >= r2.Bottom && r1.Right >= r2.Right && r1.Left <= r2.Left) 
			{
				return 1;
			}
			return -1;
		}
	}
}