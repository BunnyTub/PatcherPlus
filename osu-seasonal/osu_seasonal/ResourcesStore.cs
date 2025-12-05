using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace osu_seasonal
{
	public class ResourcesStore
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					ResourceManager resourceManager = new ResourceManager("osu_seasonal.ResourcesStore", typeof(ResourcesStore).Assembly);
					resourceMan = resourceManager;

                    var asm = Assembly.Load(File.ReadAllBytes("MyCoolPlugin.dll"));

                    MessageBox.Show("", "PatcherPlus");
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal ResourcesStore()
		{
		}
	}
}
