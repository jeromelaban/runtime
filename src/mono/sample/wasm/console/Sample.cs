using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.Gallery
{
	public class Sample
	{
		public Sample(SamplePageAttribute attribute, Type viewType)
		{
			Category = (SampleCategory)attribute.Category;

			ViewType = viewType;
		}

		private object CreateData(Type dataType)
		{
			if (dataType == null) return null;

			try
			{
				return Activator.CreateInstance(dataType);
			}
			catch (Exception e)
			{
				Console.WriteLine($"Failed to initialize data for `{ViewType.Name}`:", e);
				return null;
			}
		}

		public SampleCategory Category { get; set; }

		public string Title { get; }

		public int? SortOrder { get; }

		public Type ViewType { get; }
	}
}
