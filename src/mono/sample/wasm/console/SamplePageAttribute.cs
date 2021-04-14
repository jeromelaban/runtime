using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Uno.Gallery
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public sealed class SamplePageAttribute : Attribute
	{
		public SamplePageAttribute(long category)
		{
			Category = (int)category;
		}

		/// <summary>
		/// Sample category with null reserved for Home/Overview.
		/// </summary>
		public int Category;
	}
}
