using System;
using System.IO;

namespace Akatsuki.Loader
{
	public class Config : BaseConfig
	{
		//nullable
		public string ExecutablePath { get; set; }

		//nullable
		public string SelectedBranch { get; set; } = "stable";

		public bool AlwaysShowMisses { get; set; } = true;

		public bool AlwaysAllowFailing { get; set; }

		public static string Filename { get; } = "config.ini";

		//nullable
		public static DirectoryInfo GetFolder()
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			
			if (string.IsNullOrEmpty(folderPath))
			{
				return null;
			}

			return Directory.CreateDirectory(folderPath + "\\PatcherPlus");
		}

		public static void Save(Config config, bool create = false)
		{
			DirectoryInfo folder = GetFolder();

			if (folder == null)
			{
				return;
			}

			using (FileStream stream = new FileStream(folder.FullName + "\\" + Filename, create ? FileMode.OpenOrCreate : FileMode.Truncate))
			{
				using (StreamWriter writer = new StreamWriter(stream))
				{
					config.Save(writer);
				}
			}
		}

		public static Config Load()
		{
			Config config = new Config();
			DirectoryInfo folder = GetFolder();

			if (folder == null)
			{
				return config;
			}

			if (!File.Exists(folder.FullName + "\\" + Filename))
			{
				Save(config, create: true);
			}
			else
			{
				using (FileStream stream = new FileStream(folder.FullName + "\\" + Filename, FileMode.OpenOrCreate))
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						config.Load(reader);
					}
				}
			}

			return config;
		}
	}

}
