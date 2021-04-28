using System;

namespace GXPEngine.Core
{
	public struct Vector2
	{
		public float x;
		public float y;
		
		public Vector2 (float x, float y)
		{
			this.x = x;
			this.y = y;
		}
		

		public void Substract(Vector2 vector1, Vector2 vector2)
		{
			x = vector1.x - vector2.x;
			y = vector1.y - vector2.y;
        }



		override public string ToString() {
			return "[Vector2 " + x + ", " + y + "]";
		}
	}
}

