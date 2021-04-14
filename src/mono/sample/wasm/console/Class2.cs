using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Uno.Gallery.Views.SamplePages
{
	[SamplePage(0)]
	public sealed partial class CardSamplePage
	{
	}
}

namespace Uno.Gallery.Views.GeneralPages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	[SamplePage(1)]
	public sealed partial class CupertinoPalettePage 
	{
	}
}


namespace Uno.Gallery
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	sealed partial class App
	{
		public static IEnumerable<Sample> GetSamples()
			=> Assembly.GetExecutingAssembly()
				.DefinedTypes
				.Where(x => x.Namespace?.StartsWith("Uno.Gallery") == true)
				.Select(x => new { TypeInfo = x, SamplePageAttribute = x.GetCustomAttribute<SamplePageAttribute>() })
				.Where(x => x.SamplePageAttribute != null)
				.Select(x => new Sample(x.SamplePageAttribute, x.TypeInfo.AsType()));
	}
}
